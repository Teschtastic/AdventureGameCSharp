namespace Foundation
{
    public interface IEntity
    {
        string Name { get; }

        public void OnMessage(Message message);
    }
}
