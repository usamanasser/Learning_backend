<template>
    <div class="row">
        <div class="col-lg-12 col-md-12  ml-auto mr-auto">
            <accountdropdown v-model="addContact.accountId" v-bind:accounts="accounts" v-bind:accountsvalue="accountsvalue" v-if="loading"></accountdropdown>
        </div>
    </div>
</template>
<script>
    import axios from 'axios'
    export default {
        data: function () {
            return {
                accounts: [],
                accountsvalue: [],
                accountslevelone: [],
                addContact: {

                    accountId: '',
                },
                loading: false,
            }
},
                methods: {

                GetAccountsData: function () {
                    var root = this;
                    axios.get('/Accounting/GetCOA')
                        .then(function (response) {
                            root.Accounts = response.data;
                            root.$store.dispatch('GetAccountList', root.Accounts);
                            root.Accounts.accountTypes.forEach(function (accountType) {
                                var arr = [];
                                accountType.costCenters.forEach(function (costCenter) {

                                    costCenter.accounts.forEach(function (account) {
                                        arr.push({ name: account.code + ": " + account.name, id: account.id });
                                        root.accountslevelone.push({ name: account.code + ": " + account.name, id: account.id });
                                    });
                                });

                                root.accounts.push({
                                    AccountType: accountType.name,
                                    libs: arr
                                });
                            });

                        })
                        .then(function () {
                            root.accountsvalue = root.accountslevelone.find(function (x) {

                                return x.id == root.addContact.accountId;
                            })
                            root.loading = true;

                        });

                },
            },
            mounted: function () {
                this.GetAccountsData();



            }
        }
</script>