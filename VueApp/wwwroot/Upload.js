const Upload = {
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
                        <h1 class="display-1">Server1 externích informačních zdrojů </h1><br><br >
                        Import souborů <br />Vyberte xml soubor.
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-file-input show-size chips multiple label="Vyberte prosím soubor.."  v-model="formFiles"></v-file-input>
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitForm">Odeslat</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> Resetovat </v-btn>
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
            formFiles:null,
            Soubor: {
                //id:'',
                NazevSouboru: '',
                clanekId: '',
                slozkaSouboru: '',


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
            console.log(this.formFiles[0].name  );
            let formData = new FormData();
            this.Soubor.NazevSouboru = this.formFiles[0].name
            if (this.formFiles) {
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
                        console.log('test')
                    }).catch(function (error) {
                        this.showMsg = true;
                        this.colorMsg = 'red';
                        this.typMsg = 'error';
                        this.resultMsg = 'Nastala chyba!';
                        console.log('test1')
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