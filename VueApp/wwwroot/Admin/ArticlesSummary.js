const ArticlesSummary = {
    template: `
    <div>
            <v-container>
                <v-alert dismissible v-model="showMsg" :color='colorMsg' outlined :type='typeMsg'>
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode='out-in'>
                    <v-layout column align-start>
                        <h1 class='display-1'>Article summary <br /><br /></h1>
                    <div  v-for='article in articles'
        :key='article.id'>
                           <v-card width='400'>
      <h1>{{ article.title }}</h1>

    <p> {{ article.text }}</p>
<p> {{ article }}</p>
<v-btn color='purple' style='color:white;' type='button' @click='addToCart($event, article.id)'> Clear</v-btn>

    </v-card>
    </div>

                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type='button' @click='clear'> Claer form</v-btn>
            </v-container>
    </div>
    `,
    data:function (){
        return {
            text: 'Articles',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            articles: [],
            resp:null,
            theArray:[],

            showMsg: false,
            resultMsg: '',
            dialog: false,
        }
    },
    props: {
       
            
   
        // type check
        height: Number,
    },


    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        },
        clear() {
            this.articles = []
        },
        addToCart: function (event, id) {
            // use event here as well as id
            axios
                .delete(`/Article/Delete/`+id)
                .then(res => {
                //    for (let i = 0; i < res.data.length; i++) {

                //        var newItem = {
                //            id: res.data[i].id,
                //            title: res.data[i].title,
                //            text: res.data[i].text,
                //        };
                //        this.articles.push(newItem);
                //    }
                })


        }
    },
    created() {
        console.log('created')
        window.document.title = 'Articles summary form - Vue';
        //this.articles= [
        //        { 'id': '2a7c6470-8796-4a59-7e7b-08db223d9ced', 'title': 'sdsssf', 'text': 'we', 'autor': 'e', 'publikovanoDne': '2023-03-08T00:00:00', 'publikovanoDo': '2023-03-17T00:00:00', 'vytvorenoDne': '2023-03-20T00:00:00', 'proPrihlasene': true, 'priloha': 'e', 'poradi': 'w', 'typClanku': 5 }
        //        , { 'id': '449b1c96-6284-4fde-7e7c-08db223d9ced', 'title': 'sdf', 'text': 'we', 'autor': 'e', 'publikovanoDne': '2023-03-08T00:00:00', 'publikovanoDo': '2023-03-17T00:00:00', 'vytvorenoDne': '2023-03-20T00:00:00', 'proPrihlasene': true, 'priloha': 'e', 'poradi': 'w', 'typClanku': 5 }
        //    ]
  

    },
 
    mounted() {

        console.log('mounted')

        axios
            .get(`/Article/Summary`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        title: res.data[i].title,
                        text: res.data[i].text,
                    };
                this.articles.push(newItem);
                }
            })





     
    },
    beforeCreate: function () {

    },
}