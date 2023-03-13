const prehledKontaktu = {
    template: `
    <div>
 <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
           <th class="text-left">
          jméno
        </th>
        <th class="text-left">
          prijmení
        </th>
  <th class="text-left">
          telefon
        </th>
  <th class="text-left">
          aktivní
        </th>
  <th class="text-left">
          město
        </th>
<th class="text-left">
          akce
        </th>
        </tr>
      </thead>
      <tbody>
        <tr
        v-for="item in kontakty"
        :key="item.name"
      >
        <td>{{ item.jmeno }}</td>
        <td>{{ item.prijmeni }}</td>
        <td>{{ item.telefon }}</td>
        <td>{{ item.aktivni }}</td>
        <td>{{ item.mesto }}</td>
        <td><v-btn color='purple' style='color:white;' type='button' @click='deleteItem($event, item.id)'> clear</v-btn></td>
      </tr>
      </tbody>
    </template>
  </v-simple-table>


     
    </div>
    `,
    data() {
        return {
            text: 'Novinky',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            kontakty:[],
            Kontakt: {
                //id:'',
                jmeno: '',
                prijmeni: '',
                telefon: '',
                aktivni: false,
                mesto: '',


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
        deleteItem: function (event, id) {
            // use event here as well as id
            console.log(id)
            axios
                .delete(`/Kontakt/Delete/` + id)
                .then(res => {
                
                })


        }
    },
    created() {
        window.document.title = 'Novinky form - Vue'
    },
    mounted() {

        console.log('mounted')

        axios
            .get(`/Kontakt/Prehled`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        jmeno: res.data[i].jmeno,
                        prijmeni: res.data[i].prijmeni,
                        telefon: res.data[i].telefon,
                        aktivni: res.data[i].aktivni,
                        mesto: res.data[i].mesto,
                    };
                    this.kontakty.push(newItem);
                }
            })






    },

}