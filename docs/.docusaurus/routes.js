import React from 'react';
import ComponentCreator from '@docusaurus/ComponentCreator';

export default [
  {
    path: '/__docusaurus/debug',
    component: ComponentCreator('/__docusaurus/debug', 'e44'),
    exact: true
  },
  {
    path: '/__docusaurus/debug/config',
    component: ComponentCreator('/__docusaurus/debug/config', 'd06'),
    exact: true
  },
  {
    path: '/__docusaurus/debug/content',
    component: ComponentCreator('/__docusaurus/debug/content', '796'),
    exact: true
  },
  {
    path: '/__docusaurus/debug/globalData',
    component: ComponentCreator('/__docusaurus/debug/globalData', '923'),
    exact: true
  },
  {
    path: '/__docusaurus/debug/metadata',
    component: ComponentCreator('/__docusaurus/debug/metadata', 'e91'),
    exact: true
  },
  {
    path: '/__docusaurus/debug/registry',
    component: ComponentCreator('/__docusaurus/debug/registry', '6ec'),
    exact: true
  },
  {
    path: '/__docusaurus/debug/routes',
    component: ComponentCreator('/__docusaurus/debug/routes', '28e'),
    exact: true
  },
  {
    path: '/docs',
    component: ComponentCreator('/docs', '1eb'),
    routes: [
      {
        path: '/docs/',
        component: ComponentCreator('/docs/', '890'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/api/',
        component: ComponentCreator('/docs/api/', '733'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/api/API',
        component: ComponentCreator('/docs/api/API', '6c1'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/ecosystem/databerry',
        component: ComponentCreator('/docs/ecosystem/databerry', 'f66'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/ecosystem/helicone',
        component: ComponentCreator('/docs/ecosystem/helicone', '441'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/ecosystem/unstructured',
        component: ComponentCreator('/docs/ecosystem/unstructured', '818'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/getting-started/guide-chat',
        component: ComponentCreator('/docs/getting-started/guide-chat', '468'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/getting-started/guide-llm',
        component: ComponentCreator('/docs/getting-started/guide-llm', 'c2b'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/getting-started/install',
        component: ComponentCreator('/docs/getting-started/install', '45a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/',
        component: ComponentCreator('/docs/modules/agents/', '0d5'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/',
        component: ComponentCreator('/docs/modules/agents/agents/', '0df'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/custom_llm',
        component: ComponentCreator('/docs/modules/agents/agents/custom_llm', '912'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/custom_llm_chat',
        component: ComponentCreator('/docs/modules/agents/agents/custom_llm_chat', 'a3e'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/examples/',
        component: ComponentCreator('/docs/modules/agents/agents/examples/', '364'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/examples/chat_mrkl',
        component: ComponentCreator('/docs/modules/agents/agents/examples/chat_mrkl', '7e8'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/examples/conversational_agent',
        component: ComponentCreator('/docs/modules/agents/agents/examples/conversational_agent', 'd98'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/examples/custom_agent_chat',
        component: ComponentCreator('/docs/modules/agents/agents/examples/custom_agent_chat', '6dd'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/agents/examples/llm_mrkl',
        component: ComponentCreator('/docs/modules/agents/agents/examples/llm_mrkl', '609'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/executor/',
        component: ComponentCreator('/docs/modules/agents/executor/', '898'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/executor/getting-started',
        component: ComponentCreator('/docs/modules/agents/executor/getting-started', '45d'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/toolkits/',
        component: ComponentCreator('/docs/modules/agents/toolkits/', '6d3'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/toolkits/json',
        component: ComponentCreator('/docs/modules/agents/toolkits/json', '0f8'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/toolkits/openapi',
        component: ComponentCreator('/docs/modules/agents/toolkits/openapi', '793'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/toolkits/sql',
        component: ComponentCreator('/docs/modules/agents/toolkits/sql', '781'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/toolkits/vectorstore',
        component: ComponentCreator('/docs/modules/agents/toolkits/vectorstore', 'bc7'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/',
        component: ComponentCreator('/docs/modules/agents/tools/', '7c2'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/agents_with_vectorstores',
        component: ComponentCreator('/docs/modules/agents/tools/agents_with_vectorstores', '1e4'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/aiplugin-tool',
        component: ComponentCreator('/docs/modules/agents/tools/aiplugin-tool', 'a7b'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/integrations/',
        component: ComponentCreator('/docs/modules/agents/tools/integrations/', 'c72'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/lambda_agent',
        component: ComponentCreator('/docs/modules/agents/tools/lambda_agent', 'c09'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/webbrowser',
        component: ComponentCreator('/docs/modules/agents/tools/webbrowser', '1d1'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/agents/tools/zapier_agent',
        component: ComponentCreator('/docs/modules/agents/tools/zapier_agent', '9a0'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/',
        component: ComponentCreator('/docs/modules/chains/', 'b29'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/index_related_chains/',
        component: ComponentCreator('/docs/modules/chains/index_related_chains/', 'c79'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/index_related_chains/conversational_retrieval',
        component: ComponentCreator('/docs/modules/chains/index_related_chains/conversational_retrieval', '8af'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/index_related_chains/document_qa',
        component: ComponentCreator('/docs/modules/chains/index_related_chains/document_qa', 'dd9'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/index_related_chains/retrieval_qa',
        component: ComponentCreator('/docs/modules/chains/index_related_chains/retrieval_qa', 'e4d'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/llmchain',
        component: ComponentCreator('/docs/modules/chains/llmchain', '22b'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/other_chains/',
        component: ComponentCreator('/docs/modules/chains/other_chains/', '4c7'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/other_chains/analyze_document',
        component: ComponentCreator('/docs/modules/chains/other_chains/analyze_document', '58e'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/other_chains/constitutional_chain',
        component: ComponentCreator('/docs/modules/chains/other_chains/constitutional_chain', '659'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/other_chains/moderation_chain',
        component: ComponentCreator('/docs/modules/chains/other_chains/moderation_chain', 'e8c'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/other_chains/sql',
        component: ComponentCreator('/docs/modules/chains/other_chains/sql', 'f51'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/other_chains/summarization',
        component: ComponentCreator('/docs/modules/chains/other_chains/summarization', '306'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/prompt_selectors/',
        component: ComponentCreator('/docs/modules/chains/prompt_selectors/', 'a3f'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/chains/sequential_chain',
        component: ComponentCreator('/docs/modules/chains/sequential_chain', 'db6'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/',
        component: ComponentCreator('/docs/modules/indexes/', 'f9a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/', 'ce7'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/', 'f65'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/', '087'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/csv',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/csv', 'fe7'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/directory',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/directory', '778'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/docx',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/docx', '3f1'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/epub',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/epub', '665'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/json',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/json', '2b0'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/jsonlines',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/jsonlines', '6fd'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/notion_markdown',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/notion_markdown', '6c0'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/pdf',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/pdf', '475'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/subtitles',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/subtitles', 'cf9'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/text',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/text', 'a53'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/file_loaders/unstructured',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/file_loaders/unstructured', '0e6'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/', '6db'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/college_confidential',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/college_confidential', 'ca4'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/confluence',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/confluence', 'abe'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/gitbook',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/gitbook', '7cb'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/github',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/github', '69f'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/hn',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/hn', 'b64'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/imsdb',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/imsdb', '2be'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/s3',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/s3', '957'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/web_cheerio',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/web_cheerio', '48e'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/web_playwright',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/web_playwright', 'deb'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/document_loaders/examples/web_loaders/web_puppeteer',
        component: ComponentCreator('/docs/modules/indexes/document_loaders/examples/web_loaders/web_puppeteer', 'de9'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/',
        component: ComponentCreator('/docs/modules/indexes/retrievers/', '228'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/chatgpt-retriever-plugin',
        component: ComponentCreator('/docs/modules/indexes/retrievers/chatgpt-retriever-plugin', 'f37'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/contextual-compression-retriever',
        component: ComponentCreator('/docs/modules/indexes/retrievers/contextual-compression-retriever', '0e5'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/databerry-retriever',
        component: ComponentCreator('/docs/modules/indexes/retrievers/databerry-retriever', 'a4c'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/hyde',
        component: ComponentCreator('/docs/modules/indexes/retrievers/hyde', '478'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/metal-retriever',
        component: ComponentCreator('/docs/modules/indexes/retrievers/metal-retriever', '9dc'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/remote-retriever',
        component: ComponentCreator('/docs/modules/indexes/retrievers/remote-retriever', '816'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/supabase-hybrid',
        component: ComponentCreator('/docs/modules/indexes/retrievers/supabase-hybrid', '4ea'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/time-weighted-retriever',
        component: ComponentCreator('/docs/modules/indexes/retrievers/time-weighted-retriever', '58a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/retrievers/vectorstore',
        component: ComponentCreator('/docs/modules/indexes/retrievers/vectorstore', 'b34'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/text_splitters/',
        component: ComponentCreator('/docs/modules/indexes/text_splitters/', 'b44'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/text_splitters/examples/',
        component: ComponentCreator('/docs/modules/indexes/text_splitters/examples/', 'b0b'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/text_splitters/examples/character',
        component: ComponentCreator('/docs/modules/indexes/text_splitters/examples/character', 'd93'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/text_splitters/examples/markdown',
        component: ComponentCreator('/docs/modules/indexes/text_splitters/examples/markdown', 'a5d'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/text_splitters/examples/recursive_character',
        component: ComponentCreator('/docs/modules/indexes/text_splitters/examples/recursive_character', 'c81'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/text_splitters/examples/token',
        component: ComponentCreator('/docs/modules/indexes/text_splitters/examples/token', '9fa'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/', '677'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/', '0f2'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/chroma',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/chroma', '06f'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/hnswlib',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/hnswlib', '65d'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/memory',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/memory', '9b7'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/milvus',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/milvus', '259'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/myscale',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/myscale', 'ed5'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/opensearch',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/opensearch', '697'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/pinecone',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/pinecone', 'c8b'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/prisma',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/prisma', 'ea9'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/supabase',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/supabase', '2c5'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/indexes/vector_stores/integrations/weaviate',
        component: ComponentCreator('/docs/modules/indexes/vector_stores/integrations/weaviate', 'f75'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/',
        component: ComponentCreator('/docs/modules/memory/', 'f58'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/',
        component: ComponentCreator('/docs/modules/memory/examples/', '34a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/buffer_memory',
        component: ComponentCreator('/docs/modules/memory/examples/buffer_memory', '05a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/buffer_memory_chat',
        component: ComponentCreator('/docs/modules/memory/examples/buffer_memory_chat', '5d5'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/buffer_window_memory',
        component: ComponentCreator('/docs/modules/memory/examples/buffer_window_memory', '1dc'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/conversation_summary',
        component: ComponentCreator('/docs/modules/memory/examples/conversation_summary', 'cf1'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/motorhead_memory',
        component: ComponentCreator('/docs/modules/memory/examples/motorhead_memory', '2fa'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/memory/examples/vector_store_memory',
        component: ComponentCreator('/docs/modules/memory/examples/vector_store_memory', '0cc'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/',
        component: ComponentCreator('/docs/modules/models/', '6a1'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/chat/',
        component: ComponentCreator('/docs/modules/models/chat/', '13a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/chat/additional_functionality',
        component: ComponentCreator('/docs/modules/models/chat/additional_functionality', '8f2'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/chat/integrations',
        component: ComponentCreator('/docs/modules/models/chat/integrations', 'e14'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/embeddings/',
        component: ComponentCreator('/docs/modules/models/embeddings/', '9e6'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/embeddings/additional_functionality',
        component: ComponentCreator('/docs/modules/models/embeddings/additional_functionality', 'b3e'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/embeddings/integrations',
        component: ComponentCreator('/docs/modules/models/embeddings/integrations', '83b'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/llms/',
        component: ComponentCreator('/docs/modules/models/llms/', 'cad'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/llms/additional_functionality',
        component: ComponentCreator('/docs/modules/models/llms/additional_functionality', '032'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/models/llms/integrations',
        component: ComponentCreator('/docs/modules/models/llms/integrations', '994'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/prompts/',
        component: ComponentCreator('/docs/modules/prompts/', 'f27'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/prompts/example_selectors/',
        component: ComponentCreator('/docs/modules/prompts/example_selectors/', '648'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/prompts/output_parsers/',
        component: ComponentCreator('/docs/modules/prompts/output_parsers/', '848'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/prompts/prompt_templates/',
        component: ComponentCreator('/docs/modules/prompts/prompt_templates/', 'b90'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/prompts/prompt_templates/additional_functionality',
        component: ComponentCreator('/docs/modules/prompts/prompt_templates/additional_functionality', '599'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/schema/',
        component: ComponentCreator('/docs/modules/schema/', 'be4'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/schema/chat-messages',
        component: ComponentCreator('/docs/modules/schema/chat-messages', '24a'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/schema/document',
        component: ComponentCreator('/docs/modules/schema/document', '0b1'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/modules/schema/example',
        component: ComponentCreator('/docs/modules/schema/example', '22c'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/production/callbacks/',
        component: ComponentCreator('/docs/production/callbacks/', '0d2'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/production/callbacks/create-handlers',
        component: ComponentCreator('/docs/production/callbacks/create-handlers', 'aa7'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/production/callbacks/creating-subclasses',
        component: ComponentCreator('/docs/production/callbacks/creating-subclasses', '0ce'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/production/deployment',
        component: ComponentCreator('/docs/production/deployment', '78f'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/production/tracing',
        component: ComponentCreator('/docs/production/tracing', 'dfe'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/api',
        component: ComponentCreator('/docs/use_cases/api', '93f'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/autonomous_agents/',
        component: ComponentCreator('/docs/use_cases/autonomous_agents/', '909'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/autonomous_agents/auto_gpt',
        component: ComponentCreator('/docs/use_cases/autonomous_agents/auto_gpt', '2aa'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/autonomous_agents/baby_agi',
        component: ComponentCreator('/docs/use_cases/autonomous_agents/baby_agi', '2ee'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/personal_assistants',
        component: ComponentCreator('/docs/use_cases/personal_assistants', 'f67'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/question_answering',
        component: ComponentCreator('/docs/use_cases/question_answering', '862'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/summarization',
        component: ComponentCreator('/docs/use_cases/summarization', 'b68'),
        exact: true,
        sidebar: "sidebar"
      },
      {
        path: '/docs/use_cases/tabular',
        component: ComponentCreator('/docs/use_cases/tabular', '2de'),
        exact: true,
        sidebar: "sidebar"
      }
    ]
  },
  {
    path: '/',
    component: ComponentCreator('/', '644'),
    exact: true
  },
  {
    path: '*',
    component: ComponentCreator('*'),
  },
];
