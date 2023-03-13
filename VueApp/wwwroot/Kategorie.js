const Kategorie = {
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
                        <h1 class="display-1">Sekce administrace kategorií <br /><br /></h1>
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="popis"placeholder="Nadpis" v-model="Kategorie.nadpis"></v-text-field>
                                    <v-text-field label="popis" placeholder="popis" v-model="Kategorie.popis"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn  color="success" type="button" text @click="submitForm">Odeslat</v-btn>
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
            text: 'Kategorie',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Kategorie: {
                //id:'',
                nadpis: '',
                popis: '',
                

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
            console.log(this.Kategorie.text);
            let formData = new FormData();
            if (this.Kategorie) {
                var self = this;

                axios.post('/Kategorie/Add', this.Kategorie,
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
        window.document.title = 'Kategorie form - Vue'
    }
}