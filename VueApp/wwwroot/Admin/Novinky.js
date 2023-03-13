const Novinky = {
    template: `
    <div>
        <v-form  id="form" name="idForm">
            <v-container>
                <v-alert dismissible v-model="showMsg" :color="colorMsg" outlined :type="typeMsg">
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode="out-in">
                    <v-layout column align-start>
                        <h1 class="display-1">Sekce  novinek <br /><br /></h1>
                        Administrace novinek
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Nadpis"placeholder="Nadpis" v-model="Novinka.nadpis"></v-text-field>
                                    <v-text-field label="autor" placeholder="autor" v-model="Novinka.autor"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Novinka.text"></v-text-field>
                                    <v-date-picker v-model="Novinka.publikovanoDne"></v-date-picker>
                                    <v-date-picker v-model="Novinka.publikovanoDo"></v-date-picker>
                                    <v-date-picker v-model="Novinka.vytvorenoDne"></v-date-picker>
                                    <v-checkbox v-model="Novinka.proPrihlasene"></v-checkbox>pro prihlasene
                                    <v-text-field label="Text" placeholder="Text" v-model="Novinka.priloha"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Novinka.poradi"></v-text-field>
                                    <v-text-field type="number" label="Text" placeholder="Text" v-model="Novinka.typClanku"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn  style='color:white;' color="success" type="button" text @click="submitForm">Odeslat</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> clear</v-btn>
            </v-container>
        </v-form>
    </div>
    `,
    data() {
        return {
            text: 'Novinky',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Novinka: {
                //id:'',
                nadpis: '',
                text: '',
                autor: '',
                publikovanoDne: '',
                publikovanoDo: '',
                vytvorenoDne: '',
                proPrihlasene: false,
                priloha: '',
                poradi: '',
                typClanku: null,


            }
            ,
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
            console.log(this.Novinka.text);
            let formData = new FormData();
            if (this.Novinka) {
                var self = this;

                axios.post('/Novinka/Add', this.Novinka,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        self.showMsg = true;
                        self.colorMsg = 'green';
                        self.typMsg = 'sucess';
                        self.resultMsg = 'Upload proběhl úspěšně!';
                    }).catch(function (error) {
                        self.showMsg = true;
                        self.colorMsg = 'red';
                        self.typMsg = 'error';
                        self.resultMsg = 'Nastala chyba!';
                    })
                this.$refs.entryForm.reset()

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
        window.document.title = 'Novinky form - Vue'
    }
}