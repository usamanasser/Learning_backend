module.exports = {
        outputDir: 'wwwroot/dist',
          filenameHashing: false,
          configureWebpack: {
          optimization: {
                splitChunks: false
            },
            resolve: {
                alias: {
                    'vue$': 'vue/dist/vue.esm.js'
                }
            }
        },
        pluginOptions: {
            i18n: {
              locale: "en",
              fallbackLocale: "en",
              localeDir: "locales",
              enableInSFC: false
            }
          }
    }