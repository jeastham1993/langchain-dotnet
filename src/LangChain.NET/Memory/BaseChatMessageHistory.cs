﻿using LangChain.NET.Chat;

namespace LangChain.NET.Memory
{
    public abstract class BaseChatMessageHistory
    {
        public IList<BaseChatMessage> Messages { get; set; } = new List<BaseChatMessage>();

        public void AddUserMessage(string message)
        {
            AddMessage(new HumanChatMessage(message));
        }

        public void AddAiMessage(string message)
        {
            AddMessage(new AiChatMessage(message));
        }

        public abstract void AddMessage(BaseChatMessage message);
        public abstract void Clear();
    }
}