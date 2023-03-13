const Clanky = {
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
                        <h1 class="display-1">Sekce administrace clanků <br /><br /></h1>
                        Administrace článků
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Nadpis"placeholder="Nadpis" v-model="Clanek.nadpis"></v-text-field>
                                    <v-text-field label="autor" placeholder="autor" v-model="Clanek.autor"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Clanek.text"></v-text-field>
                                    <v-date-picker v-model="Clanek.publikovanoDne"></v-date-picker>
                                    <v-date-picker v-model="Clanek.publikovanoDo"></v-date-picker>
                                    <v-date-picker v-model="Clanek.vytvorenoDne"></v-date-picker>
                                    <v-checkbox v-model="Clanek.proPrihlasene"></v-checkbox>pro prihlasene
                                    <v-text-field label="Text" placeholder="Text" v-model="Clanek.priloha"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Clanek.poradi"></v-text-field>
                                    <v-text-field type="number" label="Text" placeholder="Text" v-model="Clanek.typClanku"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitForm">Odeslat</v-btn>
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
            text: 'Clanky',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Clanek: {
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
            console.log(this.Clanek.text);
            let formData = new FormData();
            if (this.Clanek) {
                var self = this;
                axios.post('/Clanek/Add', this.Clanek,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        self.showMsg= true;
                        self.colorMsg = 'green';
                        self.typeMsg = 'success';
                        self.resultMsg = 'Upload proběhl úspěšně!';
                        console.log('uspech')

                    }).catch(function (error) {
                        self.showMsg = true;
                        self.colorMsg = 'red';
                        self.typeMsg = 'error';
                        self.resultMsg = 'Nastala chyba!';
                        console.log('chyba' + error)

                    })
                this.$refs.entryForm.reset()
                console.log('konec axiosu')


            }
            else {
                this.showMsg = true;
                this.colorMsg = 'yellow';
                this.typeMsg = 'warning';
                this.resultMsg = 'Nebyl zvolen žádný soubor!';
                console.log('nevyplneno')

            }
        }
    },
    created() {
        window.document.title = 'Clanky form - Vue'
    }
}