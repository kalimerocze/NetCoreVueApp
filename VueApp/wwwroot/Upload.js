const Upload = {
    template: `
    <div>
        <v-form  id='form' name='idForm'>
            <v-container>
                <v-alert dismissible v-model='showMsg' :color='colorMsg' outlined :type='typeMsg'>
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode='out-in'>
                    <v-layout column align-start>
                        <h1 class='display-1'>Server1 externích informačních zdrojů </h1><br><br >
                        Import souborů <br />Vyberte xml soubor.
                        <v-form class='block' ref='entryForm'>
                            <v-container>
                                <v-flex>
                                    <v-file-input show-size chips  label='Vyberte prosím soubor..'   @change='uploadFile' v-model='Images'></v-file-input>

                             </v-flex>
                                <v-flex>
                                    <v-btn color='success' type='button' text @click='submitForm'>Odeslat</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type='button' @click='clear'> Resetovat </v-btn>
            </v-container>
        </v-form>
    </div>
    `,
    data() {

      //  <div>aaa
      //      <input type='file' @change='uploadFile' ref='file'>
      //      <button @click='submitFile'>Upload!</button>
      //</div >   
        return {
            text: 'Soubor',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            formFiles: null,
            Images: null,
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
        uploadFile() {
            console.log('metoda zavolana uspesne')
            console.log(this.Images) 
        },

        submitForm: function () {
            var self = this;

            let formData = new FormData();
            formData.append('file', self.Images);
            console.log(self.Images)
            console.log(formData)
            //this.Soubor.NazevSouboru = this.formFiles[0].name
            console.log(self.Images );
            if (self.Images) {
                axios.post('/Common/Upload', formData,
                    {
                        //headers: {
                        //    'Content-Type': 'multipart/form-data' 
                        //}
                    }).then(function (response) {
                        self.showMsg = true;
                        self.colorMsg = 'green';
                        self.typMsg = 'sucess';
                        self.resultMsg = 'Upload proběhl úspěšně!';
                        console.log('test')
                    }).catch(function (error) {
                        self.showMsg = true;
                        self.colorMsg = 'red';
                        self.typMsg = 'error';
                        self.resultMsg = 'Nastala chyba!' + error;
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