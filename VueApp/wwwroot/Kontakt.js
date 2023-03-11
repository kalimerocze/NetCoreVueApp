const Kontakty = {
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
                        <h1 class="display-1">Přehled kontaktů <br /><br /></h1>
                    
                            <v-simple-table dense  style='width:100vw;'>
                     <thead>
      <tr>
        <th class="text-left">
          Id
        </th>
        <th class="text-left">
          Jméno
        </th>
        <th class="text-left">
          Přijmení
        </th>
        <th class="text-left">
          Telefon
        </th>
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="(kontakt,i ) in kontakty"
        :key="i"
      >
        <td>{{ kontakt.id }}</td>
        <td>{{ kontakt.jmeno }}</td>
        <td>{{ kontakt.prijmeni }}</td>
        <td>{{ kontakt.telefon }}</td>
      </tr>
    </tbody>
  </v-simple-table >


                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> clear</v-btn>
            </v-container>
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
                id:'',
                jmeno: '',
                prijmeni: '',
               telefon:''


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