using Apache.NMS;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shared.Extensions.ActiveMQ;
using Shared.Shared.ActiveMQ_Models;
using Shared.Shared.ApiModels;
using System;
using System.Linq;

namespace Tamago_Bank.Controllers
{
	[ApiController]
	[Route("active")]
	public class ActiveMQController : Controller
	{
		private IMongoCollection<WalletModel> _bankcollection;
		private readonly IActiveMqLog _activeMQLog;

		public ActiveMQController(IMongoClient client, IActiveMqLog activeMQLog)
		{
			var database = client.GetDatabase("Bank_Database");
			_bankcollection = database.GetCollection<WalletModel>("CWallet");
			_activeMQLog = activeMQLog;

			ListenToMessage();
		}

		public async void ListenToMessage()
		{
			_activeMQLog.ConnectListener("Shop.buyItem.queue");
			var listener = _activeMQLog.GetMessageConsumer();

			listener.Listener += new MessageListener(UponMessage);
		}

		public void UponMessage(IMessage received)
		{
			_activeMQLog.ConnectSender("Bank.buyItemResponse.queue");
			var producer = _activeMQLog.GetMessageProducer();
			ITextMessage objectMessage = received as ITextMessage;
			ItemModel m = _activeMQLog.ConvertIMessageToObject<ItemModel>(objectMessage);
			Guid id = m.userId;
			var filter = Builders<WalletModel>.Filter.Eq("userId", id);
			var allData = _bankcollection.Find(Builders<WalletModel>.Filter.Empty).ToList();
			var data = allData.Where(x => x.userId == id).FirstOrDefault();

			if (data.balance < m.price)
				m.confirmation = false;
			else
				m.confirmation = true;

			var update = Builders<WalletModel>.Update.Set("balance", data.balance - m.price);
			_bankcollection.UpdateOne(filter, update);

			var res = _activeMQLog.ConvertObjectToIMessage<ItemModel>(m);
			producer.Send(res);
		}

		[HttpGet]
		public async void Get()
		{
			
		}
	}
}
