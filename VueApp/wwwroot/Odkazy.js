const Odkazy = {
    template: `
  <div>
        <v-form ref="entryForm" id="form" name="idForm">
            <v-container>
                <v-alert dismissible v-model="showMsg" :color="colorMsg" outlined :type="typeMsg">
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode="out-in">
                    <v-layout column align-start>
                        <h1 class="display-1">Sekce administrace <br /><br /></h1>
                        Administrace článků
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Nadpis" placeholder="Nadpis" v-model="Odkaz.url"></v-text-field>
                                    <v-text-field label="autor" placeholder="autor" v-model="Odkaz.text"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Odkaz.popis"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Odkaz.typOdkazu" type="number"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Odkaz.skupinaOdkazu"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Odkaz.blokOdkazu"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Odkaz.poradi" type="number"></v-text-field>
                                    <v-checkbox v-model="Odkaz.zverejnit"></v-checkbox>pro prihlasene
                                    <v-checkbox v-model="Odkaz.noveokno"></v-checkbox>pro prihlasene
                                    <v-checkbox v-model="Odkaz.proPrihlasene"></v-checkbox>pro prihlasene
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitForm">Odeslat</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
                <v-btn type="button" @click="clear"> clear</v-btn>
            </v-container>
        </v-form>
    </div>
    `,
    data() {
        return {
            text: 'Odkazy',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Odkaz: {
                //id:'',
                url: '',
                text: '',
                popis: '',
                typOdkazu: '',
                skupinaOdkazu: '',
                blokOdkazu: '',
                poradi: '',
                zverejnit: false,
                noveOkno: false,
                proPrihlasene: false,


            },
            showMsg: false,
            resultMsg: '',
            dialog: false,
        }
    },
    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        },
        clear() {
            this.$refs.entryForm.reset()

        },
        submitForm: function () {
            let formData = new FormData();
            if (this.Odkaz) {
            
                axios.post('/Common/Odkaz', this.Odkaz,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        this.showMsg = true;
                        this.colorMsg = 'green';
                        this.typMsg = 'sucess';
                        this.resultMsg = 'Upload proběhl úspěšně!';
                    }).catch(function (error) {
                        this.showMsg = true;
                        this.colorMsg = 'red';
                        this.typMsg = 'error';
                        this.resultMsg = 'Nastala chyba!';
                    })
            }
            else {
                this.showMsg = true;
                this.colorMsg = 'yellow';
                this.typMsg = 'warning';
                this.resultMsg = 'Nebyl zvolen žádný soubor!';
            }
        }
    },
    created() {
        window.document.title = 'Odkazy form - Vue'
    }
}