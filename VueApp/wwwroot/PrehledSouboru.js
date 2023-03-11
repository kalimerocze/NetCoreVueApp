const prehledSouboru = {
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
                        <h1 class="display-1">Přehled souborů <br /><br /></h1>
                                     <v-simple-table dense  style='width:100vw;'>
                     <thead>
      <tr>
        <th class="text-left">
          Id
        </th>
        <th class="text-left">
          Nadpis
        </th>
        <th class="text-left">
          Url
        </th>
        
      </tr>
    </thead>
    <tbody>
      <tr
        v-for="(item,i ) in soubory"
        :key="i"
      >
        <td>{{ item.id }}</td>
        <td>{{ item.nadpis }}</td>
        <td>{{ item.url }}</td>
      </tr>
    </tbody>
  </v-simple-table >
                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> clear </v-btn>
            </v-container>
        </v-form>
    </div>

    `,
    data() {
        return {
            text: 'PrehledSouborů',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            soubory: [
                { id: 1, nadpis: 'test.txt', url: 'http//:...' },
                { id: 2, nadpis: 'tets1.txt', url: 'http//:...' },
                { id: 3, nadpis: 'tets2.txt', url: 'http//:...' }


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
            this.soubory = []
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
        window.document.title = 'Prehled souborů form - Vue'
    }
}