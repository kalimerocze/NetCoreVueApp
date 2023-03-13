const Kontakty = {
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
                        <h1 class="display-1">Sekce  Kontaktů <br /><br /></h1>
                        Administrace novinek
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Jmeno"placeholder="Jméno" v-model="Kontakt.Jmeno"></v-text-field>
                                    <v-text-field label="prijmeni" placeholder="autor" v-model="Kontakt.prijmeni"></v-text-field>
                                    <v-text-field label="telefon" placeholder="Text" v-model="Kontakt.telefon"></v-text-field>
                                    <v-checkbox v-model="Kontakt.aktivni"></v-checkbox>aktivni
                                    <v-text-field label="mesto" placeholder="Text" v-model="Kontakt.mesto"></v-text-field>
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
            text: 'Kontakty',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            kontakty: [
                { id: 1, jmeno: 'Petr', prijmeni: 'Pavel', telefon :'444222111'},
                { id: 2, jmeno: 'Marek', prijmeni: 'Novák', telefon: '444222111' },
                { id: 3, jmeno: 'Radek', prijmeni: 'Novák', telefon: '444222111' },
                { id: 4, jmeno: 'Kateřina', prijmeni: 'Nováková', telefon: '444222111' }
        ],
            Kontakt: {
                //id:'',
                jmeno: '',
                prijmeni: '',
               telefon:'',
               mesto:'',
               aktivni:true,


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
            var self = this;

            let formData = new FormData();
            if (this.Kontakt) {
                axios.post('/Kontakt/Add', this.Kontakt,
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
        window.document.title = 'Kontakty form - Vue'
    }
}