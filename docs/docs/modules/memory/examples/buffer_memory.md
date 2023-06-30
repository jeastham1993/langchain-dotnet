# Buffer Memory

BufferMemory is the simplest type of memory - it just remembers previous conversational back and forths directly.

```typescript
import { OpenAI } from "langchain/llms/openai";
import { BufferMemory } from "langchain/memory";
import { ConversationChain } from "langchain/chains";

const model = new OpenAI({});
const memory = new BufferMemory();
const chain = new ConversationChain({ llm: model, memory: memory });
const res1 = await chain.call({ input: "Hi! I'm Jim." });
console.log({ res1 });
```

```shell
{response: " Hi Jim! It's nice to meet you. My name is AI. What would you like to talk about?"}
```

```typescript
const res2 = await chain.call({ input: "What's my name?" });
console.log({ res2 });
```

```shell
{response: ' You said your name is Jim. Is there anything else you would like to talk about?'}
```

You can also load messages into a `BufferMemory` instance by creating and passing in a `ChatHistory` object.
This lets you easily pick up state from past conversations:

```typescript
import { ChatMessageHistory } from "langchain/memory";
import { HumanChatMessage, AIChatMessage } from "langchain/schema";

const pastMessages = [
  new HumanChatMessage("My name's Jonas"),
  new AIChatMessage("Nice to meet you, Jonas!"),
];

const memory = new BufferMemory({
  chatHistory: new ChatMessageHistory(pastMessages),
});
```
