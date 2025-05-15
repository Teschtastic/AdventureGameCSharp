namespace Foundation
{
    public class Message
    {
        public Message(IEntity sender, IEntity receiver)
        {
            Sender = sender;
            Receiver = receiver;
            Type = "";
            Data = "";
        }

        public Message(IEntity sender, IEntity receiver, string type, string data)
        {
            Sender = sender;
            Receiver = receiver;
            Type = type;
            Data = data;
        }

        public IEntity Sender;
        public IEntity Receiver;
        public string Type;
        public string Data;

        public string GetMessageType()
        {
            return Type;
        }

        public void SetMessageType(string type)
        {
            Type = type;
        }

        public string GetMessageData()
        {
            return Data;
        }

        public void SetMessageData(string data)
        {
            Data = data;
        }

        public void AppendMessageData(string data)
        {
            Data += data;
        }

        public void ClearMessageData()
        {
            Type = "";
            Data = "";
        }
    }

    public class MessageQueue
    {
        public Queue<Message> queue = [];

        public void AddToQueue(Message message)
        {
            queue.Enqueue(message);
        }

        public Message DeleteFromQueue()
        {
            return queue.Dequeue();
        }

        public void Dispatch()
        {
            IEntity entity;

            while (queue.Count > 0)
            {
                Message message = queue.Dequeue();

                if (message != null)
                {
                    entity = message.Receiver;

                    entity?.OnMessage(message);
                }
            }
        }

        public void ClearQueue()
        {
            queue.Clear();
        }
    }
}
