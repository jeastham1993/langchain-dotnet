/*
 * AUTOGENERATED - DON'T EDIT
 * Your edits in this file will be overwritten in the next build!
 * Modify the docusaurus.config.js file at your site's root instead.
 */
export default {
  "title": "🦜️🔗 Langchain",
  "tagline": "LangChain JS Docs",
  "favicon": "img/favicon.ico",
  "customFields": {},
  "url": "https://dotnet.langchain.com",
  "baseUrl": "/",
  "onBrokenLinks": "throw",
  "onBrokenMarkdownLinks": "throw",
  "plugins": [
    [
      "docusaurus-plugin-typedoc",
      {
        "tsconfig": "../langchain/tsconfig.json"
      }
    ],
    null
  ],
  "presets": [
    [
      "classic",
      {
        "docs": {
          "sidebarPath": "/Users/jameseastham/source/github/langchain-dotnet/docs/sidebars.js",
          "editUrl": "https://github.com/hwchase17/langchainjs/edit/main/docs/",
          "remarkPlugins": [
            [
              null,
              {
                "sync": true
              }
            ]
          ]
        },
        "pages": {
          "remarkPlugins": [
            null
          ]
        },
        "theme": {
          "customCss": "/Users/jameseastham/source/github/langchain-dotnet/docs/src/css/custom.css"
        }
      }
    ]
  ],
  "themeConfig": {
    "prism": {
      "theme": {
        "plain": {
          "color": "#000000",
          "backgroundColor": "#ffffff"
        },
        "styles": [
          {
            "types": [
              "comment"
            ],
            "style": {
              "color": "rgb(0, 128, 0)"
            }
          },
          {
            "types": [
              "builtin"
            ],
            "style": {
              "color": "rgb(0, 112, 193)"
            }
          },
          {
            "types": [
              "number",
              "variable",
              "inserted"
            ],
            "style": {
              "color": "rgb(9, 134, 88)"
            }
          },
          {
            "types": [
              "operator"
            ],
            "style": {
              "color": "rgb(0, 0, 0)"
            }
          },
          {
            "types": [
              "constant",
              "char"
            ],
            "style": {
              "color": "rgb(129, 31, 63)"
            }
          },
          {
            "types": [
              "tag"
            ],
            "style": {
              "color": "rgb(128, 0, 0)"
            }
          },
          {
            "types": [
              "attr-name"
            ],
            "style": {
              "color": "rgb(255, 0, 0)"
            }
          },
          {
            "types": [
              "deleted",
              "string"
            ],
            "style": {
              "color": "rgb(163, 21, 21)"
            }
          },
          {
            "types": [
              "changed",
              "punctuation"
            ],
            "style": {
              "color": "rgb(4, 81, 165)"
            }
          },
          {
            "types": [
              "function",
              "keyword"
            ],
            "style": {
              "color": "rgb(0, 0, 255)"
            }
          },
          {
            "types": [
              "class-name"
            ],
            "style": {
              "color": "rgb(38, 127, 153)"
            }
          }
        ]
      },
      "darkTheme": {
        "plain": {
          "color": "#9CDCFE",
          "backgroundColor": "#1E1E1E"
        },
        "styles": [
          {
            "types": [
              "prolog"
            ],
            "style": {
              "color": "rgb(0, 0, 128)"
            }
          },
          {
            "types": [
              "comment"
            ],
            "style": {
              "color": "rgb(106, 153, 85)"
            }
          },
          {
            "types": [
              "builtin",
              "changed",
              "keyword",
              "interpolation-punctuation"
            ],
            "style": {
              "color": "rgb(86, 156, 214)"
            }
          },
          {
            "types": [
              "number",
              "inserted"
            ],
            "style": {
              "color": "rgb(181, 206, 168)"
            }
          },
          {
            "types": [
              "constant"
            ],
            "style": {
              "color": "rgb(100, 102, 149)"
            }
          },
          {
            "types": [
              "attr-name",
              "variable"
            ],
            "style": {
              "color": "rgb(156, 220, 254)"
            }
          },
          {
            "types": [
              "deleted",
              "string",
              "attr-value",
              "template-punctuation"
            ],
            "style": {
              "color": "rgb(206, 145, 120)"
            }
          },
          {
            "types": [
              "selector"
            ],
            "style": {
              "color": "rgb(215, 186, 125)"
            }
          },
          {
            "types": [
              "tag"
            ],
            "style": {
              "color": "rgb(78, 201, 176)"
            }
          },
          {
            "types": [
              "tag"
            ],
            "languages": [
              "markup"
            ],
            "style": {
              "color": "rgb(86, 156, 214)"
            }
          },
          {
            "types": [
              "punctuation",
              "operator"
            ],
            "style": {
              "color": "rgb(212, 212, 212)"
            }
          },
          {
            "types": [
              "punctuation"
            ],
            "languages": [
              "markup"
            ],
            "style": {
              "color": "#808080"
            }
          },
          {
            "types": [
              "function"
            ],
            "style": {
              "color": "rgb(220, 220, 170)"
            }
          },
          {
            "types": [
              "class-name"
            ],
            "style": {
              "color": "rgb(78, 201, 176)"
            }
          },
          {
            "types": [
              "char"
            ],
            "style": {
              "color": "rgb(209, 105, 105)"
            }
          }
        ]
      },
      "additionalLanguages": [],
      "magicComments": [
        {
          "className": "theme-code-block-highlighted-line",
          "line": "highlight-next-line",
          "block": {
            "start": "highlight-start",
            "end": "highlight-end"
          }
        }
      ]
    },
    "image": "img/parrot-chainlink-icon.png",
    "navbar": {
      "title": "🦜️🔗 LangChain",
      "items": [
        {
          "href": "https://docs.langchain.com/docs/",
          "label": "Concepts",
          "position": "left"
        },
        {
          "href": "https://python.langchain.com/en/latest/",
          "label": "Python Docs",
          "position": "left"
        },
        {
          "to": "/docs/",
          "label": "JS/TS Docs",
          "position": "left"
        },
        {
          "href": "https://github.com/hwchase17/langchainjs",
          "label": "GitHub",
          "position": "right"
        }
      ],
      "hideOnScroll": false
    },
    "footer": {
      "style": "light",
      "links": [
        {
          "title": "Community",
          "items": [
            {
              "label": "Discord",
              "href": "https://discord.gg/cU2adEyC7w"
            },
            {
              "label": "Twitter",
              "href": "https://twitter.com/LangChainAI"
            }
          ]
        },
        {
          "title": "GitHub",
          "items": [
            {
              "label": "Python",
              "href": "https://github.com/hwchase17/langchain"
            },
            {
              "label": "JS/TS",
              "href": "https://github.com/hwchase17/langchainjs"
            }
          ]
        },
        {
          "title": "More",
          "items": [
            {
              "label": "Homepage",
              "href": "https://langchain.com"
            },
            {
              "label": "Blog",
              "href": "https://blog.langchain.dev"
            }
          ]
        }
      ],
      "copyright": "Copyright © 2023 LangChain, Inc."
    },
    "colorMode": {
      "defaultMode": "light",
      "disableSwitch": false,
      "respectPrefersColorScheme": false
    },
    "docs": {
      "versionPersistence": "localStorage",
      "sidebar": {
        "hideable": false,
        "autoCollapseCategories": false
      }
    },
    "metadata": [],
    "tableOfContents": {
      "minHeadingLevel": 2,
      "maxHeadingLevel": 3
    }
  },
  "baseUrlIssueBanner": true,
  "i18n": {
    "defaultLocale": "en",
    "path": "i18n",
    "locales": [
      "en"
    ],
    "localeConfigs": {}
  },
  "onDuplicateRoutes": "warn",
  "staticDirectories": [
    "static"
  ],
  "themes": [],
  "scripts": [],
  "headTags": [],
  "stylesheets": [],
  "clientModules": [],
  "titleDelimiter": "|",
  "noIndex": false,
  "markdown": {
    "mermaid": false
  }
};
