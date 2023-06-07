const NewsSummary = {
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
                        <h1 class="display-1">News summary <br /><br /></h1>
                   <div  v-for='item in news'
        :key='item.id'>
                           <v-card width="400">
      <h1>{{ item.title }}</h1>

    <p> {{ item.text }}</p>
<v-btn color='purple' style='color:white;' type='button' @click='deleteItem($event, item.id)'> Clear</v-btn>


    </v-card>
    </div>

             


                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> Clear form</v-btn>
            </v-container>
    </div>
    `,
    data() {
        return {
            text: 'News',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            news: [
                //{ id: 1, title: 'Marek', telo: 'Novák'},
                //{ id: 2, title: 'Marek', telo: 'Novák'},
                //{ id: 3, title: 'Marek', telo: 'Novák'}
                
              
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
                .delete(`/News/Delete/` + id)
                .then(res => {
                    //    for (let i = 0; i < res.data.length; i++) {

                    //        var newItem = {
                    //            id: res.data[i].id,
                    //            title: res.data[i].title,
                    //            text: res.data[i].text,
                    //        };
                    //        this.clanky.push(newItem);
                    //    }
                })


        }

    
    },


    created() {
        window.document.title = 'News summary form - Vue'
    },
        mounted() {

        console.log('mounted')

        axios
            .get(`/News/Summary`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        title: res.data[i].title,
                        text: res.data[i].text,
                    };
                    this.news.push(newItem);
                }
            })






    },

}