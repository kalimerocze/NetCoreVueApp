const ContactsSummary = {
    template: `
    <div>
 <v-simple-table>
    <template v-slot:default>
      <thead>
        <tr>
           <th class="text-left">
          Name
        </th>
        <th class="text-left">
          Surname
        </th>
  <th class="text-left">
          Phone
        </th>
  <th class="text-left">
          Active
        </th>
  <th class="text-left">
          City
        </th>
<th class="text-left">
          Action
        </th>
        </tr>
      </thead>
      <tbody>
        <tr
        v-for="item in contacts"
        :key="item.name"
      >
        <td>{{ item.name }}</td>
        <td>{{ item.surname }}</td>
        <td>{{ item.phone }}</td>
        <td>{{ item.active }}</td>
        <td>{{ item.city }}</td>
        <td><v-btn color='purple' style='color:white;' type='button' @click='deleteItem($event, item.id)'>Clear from</v-btn></td>
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
            contacts:[],
            Kontakt: {
                //id:'',
                name: '',
                surname: '',
                phone: '',
                active: false,
                city: '',


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
                .delete(`/Contact/Delete/` + id)
                .then(res => {
                
                })


        }
    },
    created() {
        window.document.title = 'Contacts - Vue'
    },
    mounted() {

        console.log('mounted')

        axios
            .get(`/Contact/Summary`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        name: res.data[i].name,
                        surname: res.data[i].surname,
                        phone: res.data[i].phone,
                        active: res.data[i].active,
                        city: res.data[i].city,
                    };
                    this.contacts.push(newItem);
                }
            })






    },

}