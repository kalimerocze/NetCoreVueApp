const Soubor = {
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
                        <h1 class="display-1">Sekce administrace souborů <br /><br /></h1>
                        Administrace souborů
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Nadpis" placeholder="Nadpis" v-model="Soubor.nadpis"></v-text-field>
                                    <v-text-field label="autor" placeholder="autor" v-model="Soubor.autor"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Soubor.text"></v-text-field>
                                    <v-date-picker v-model="Soubor.publikovanoDne"></v-date-picker>
                                    <v-date-picker v-model="Soubor.publikovanoDo"></v-date-picker>
                                    <v-date-picker v-model="Soubor.vytvorenoDne"></v-date-picker>
                                    <v-checkbox v-model="Soubor.proPrihlasene"></v-checkbox>
                                    <v-text-field label="Text" placeholder="Text" v-model="Soubor.priloha"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Soubor.poradi"></v-text-field>
                                    <v-text-field type="number" label="Text" placeholder="Text" v-model="Soubor.typClanku"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitForm">Odeslat</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> clear </v-btn>
            </v-container>
        </v-form>
    </div>

    `,
    data() {
        return {
            text: 'Soubor',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Soubor: {
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
            console.log(this.Soubor.text);
            let formData = new FormData();
            if (this.Soubor) {
                axios.post('/Common/Upload', this.Soubor,
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
        window.document.title = 'Soubor form - Vue'
    }
}