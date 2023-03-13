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
          Nazev souboru
        </th>
        <th class="text-left">
          Slozka souboru
        </th>
<th class="text-left">
          Akce
        </th>
        
      </tr>
    </thead>
    <tbody>
      <tr
        v-for='item in soubory'
        :key='item.id'>
    
        <td>{{ item.id }}</td>
        <td>{{ item.nazevSouboru }}</td>
        <td>{{ item.slozkaSouboru }}</td>
  <td> <v-btn color='purple' style='color:white;' type='button' @click='deleteItem($event, item.id)'> Delete</v-btn> </td>
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
                //{ id: 1, nazevSouboru: 'test.txt', slozkaSouboru: 'http//:...' },
                //{ id: 2, nazevSouboru: 'tets1.txt', slozkaSouboru: 'http//:...' },
                //{ id: 3, nazevSouboru: 'tets2.txt', slozkaSouboru: 'http//:...' }


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
        deleteItem: function (event, id) {
            // use event here as well as id
            console.log(id)
            var self = this;
    
            axios
                .delete(`/Common/DeleteSoubor/` + id)
                .then(res => {
                    self.showMsg = true;
                    self.colorMsg = 'green';
                    self.typMsg = 'sucess';
                    self.resultMsg = 'Soubor byl úspěšně smazán!';
                })

        }
    },
    created() {
        window.document.title = 'Prehled souborů form - Vue'
    },
    mounted() {

        console.log('mounted')

        axios
            .get(`/Common/Soubory`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        nazevSouboru: res.data[i].nazevSouboru,
                        slozkaSouboru: res.data[i].slozkaSouboru,
                    };
                    this.soubory.push(newItem);
                    console.log(newItem)
                  
                }
            })






    },

}