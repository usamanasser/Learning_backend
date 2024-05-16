import vue from 'vue'
import Vuelidate from 'vuelidate'
import VueSweetalert2 from 'vue-sweetalert2';
import vuex from 'vuex';
import VueSweetAlert from 'vue-sweetalert'
import ElementUI from 'element-ui'
import locale from 'element-ui/lib/locale/lang/en'
/*import 'element-ui/lib/theme-chalk/index.css';*/
import vueCountryRegionSelect from 'vue-country-region-select'
import { BPagination } from 'bootstrap-vue'
import TextareaAutosize from 'vue-textarea-autosize'
import VueApexCharts from 'vue-apexcharts'
import i18n from './i18n'
vue.use(VueApexCharts);
vue.component('apexchart', VueApexCharts);
vue.use(TextareaAutosize);
// register component <percent-input>
vue.use(vueCountryRegionSelect);
vue.use(ElementUI, { locale });
vue.use(vuex);
vue.component('b-pagination', BPagination);

import vueHtmlToPaper from 'vue-html-to-paper';
vue.use(vueHtmlToPaper);

vue.use(VueSweetalert2);
vue.use(Vuelidate);
vue.use(VueSweetAlert);

var getLocale = sessionStorage.getItem('locales');
let language = getLocale;
if (!language) {
    language = 'en'
}
i18n.locale = language;


vue.config.productionTip = false;
vue.config.devtools = true;

vue.component('helloworld', require('./components/HelloWorld.vue').default);

const store = new vuex.Store({
    state: {
        zoneList: [],
    },
    actions: {
        GetZoneList: function (commit, zoneList) {
            store.state.zoneList = zoneList;
        },
        
    }
});

new vue({
    store,
    i18n
}).$mount('#focus');

window.Vue = vue;
