const prehledNovinky = {
    template: `
    <div>
            <v-container>
                <v-alert dismissible v-model="showMsg" :color="colorMsg" outlined :type="typeMsg">
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode="out-in">
                    <v-layout column align-start>
                        <h1 class="display-1">Přehled novinek <br /><br /></h1>
                    <div v-for="(novinka,i ) in novinky"
        :key="i">
                           <v-card width="400">
      <h1>{{ novinka.id }}</h1>

    <p> {{ novinka.telo }}</p>

    </v-card>
    </div>

              


                    </v-layout>
                </v-slide-y-transition>
                <v-btn type="button" @click="clear"> clear</v-btn>
            </v-container>
    </div>
    `,
    data() {
        return {
            text: 'Novinky',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            novinky: [
                { id: 1, nadpis: 'Marek', telo: 'Novák'},
                { id: 2, nadpis: 'Marek', telo: 'Novák'},
                { id: 3, nadpis: 'Marek', telo: 'Novák'}
                
              
        ],
           
            
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
            console.log(this.Kontakt.text);
            let formData = new FormData();
            if (this.Kontakt) {
                axios.post('/Common/Upload', this.Kontakt,
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
        window.document.title = 'Kontakty form - Vue'
    }
}