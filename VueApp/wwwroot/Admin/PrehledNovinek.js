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
                   <div  v-for='novinka in novinky'
        :key='novinka.id'>
                           <v-card width="400">
      <h1>{{ novinka.nadpis }}</h1>

    <p> {{ novinka.text }}</p>
<v-btn color='purple' style='color:white;' type='button' @click='deleteItem($event, novinka.id)'> clear</v-btn>


    </v-card>
    </div>

             


                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> clear</v-btn>
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
                //{ id: 1, nadpis: 'Marek', telo: 'Novák'},
                //{ id: 2, nadpis: 'Marek', telo: 'Novák'},
                //{ id: 3, nadpis: 'Marek', telo: 'Novák'}
                
              
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
        deleteItem: function (event, id) {
            // use event here as well as id
            console.log(id)
            axios
                .delete(`/Novinka/Delete/` + id)
                .then(res => {
                    //    for (let i = 0; i < res.data.length; i++) {

                    //        var newItem = {
                    //            id: res.data[i].id,
                    //            nadpis: res.data[i].nadpis,
                    //            text: res.data[i].text,
                    //        };
                    //        this.clanky.push(newItem);
                    //    }
                })


        }

    
    },


    created() {
        window.document.title = 'Kontakty form - Vue'
    },
        mounted() {

        console.log('mounted')

        axios
            .get(`/Novinka/Prehled`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        nadpis: res.data[i].nadpis,
                        text: res.data[i].text,
                    };
                    this.novinky.push(newItem);
                }
            })






    },

}