using Foundation;
using static Foundation.Globals;

namespace AdventureGame.Game
{
    public class GameState(MessageQueue messageQueue)
    {
        public List<IEntity> Entities { get; private set; } = [];
        public MessageQueue MessageQueue { get; private set; } = messageQueue;
        public Message? Message { get; private set; }
        public EState CurrentState = EState.Base;
        public EState PreviousState = EState.Base;

        public void CreateNewMessageAndAddToQueue(IEntity sender, IEntity receiver, string messageType, string messageData)
        {
            Message = new(sender, receiver, messageType, messageData);
            MessageQueue.AddToQueue(Message);
        }

        public void AppendDataToMessage(string newMessage)
        {
            Message!.AppendMessageData(newMessage);
        }

        public void UpdateMessageType(string newType)
        {
            Message!.SetMessageType(newType);
        }

        public void AppendDataToMessageAndUpdateType(string newMessage, string newType)
        {
            Message!.AppendMessageData(newMessage);
            Message!.SetMessageType(newType);
        }

        public void AddToQueue()
        {
            MessageQueue.AddToQueue(Message!);
        }

        public void UpdateState(EState state)
        {
            PreviousState = CurrentState;
            CurrentState = state;
        }

        public void ProcessQueue()
        {
            MessageQueue.Dispatch();
        }

        public void AddEntity(IEntity entity)
        {
            Entities.Add(entity);
        }

        public void AddEntities(ICollection<IEntity> entities)
        {
            Entities.AddRange(entities);
        }

        public void RemoveEntity(IEntity entity)
        {
            Entities.Remove(entity);
        }

        public void RemoveEntities(ICollection<IEntity> entities)
        {
            foreach (IEntity entity in entities)
            {
                Entities.Remove(entity);
            }
        }

        public void Clear()
        {
            Entities.Clear();
        }
    }
}
