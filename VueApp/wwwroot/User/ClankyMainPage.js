const clankyMainPage = {
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
                        <h1 class='display-1'>Přehled článků <br /><br /></h1>
                    <div  v-for='clanek in clanky'
        :key='clanek.id'>
                           <v-card width='400'>
      <h1>{{ clanek.nadpis }}</h1>

    <p> {{ clanek.text }}</p>
<p> {{ clanek }}</p>

    </v-card>
    </div>

                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type='button' @click='clear'> clear</v-btn>
            </v-container>
    </div>
    `,
    data:function (){
        return {
            text: 'Články',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            clanky: [],
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
            this.clanky = []
        },
    },
    created() {
        console.log('created')
        window.document.title = 'Prehled clanku form - Vue';
        //this.clanky= [
        //        { 'id': '2a7c6470-8796-4a59-7e7b-08db223d9ced', 'nadpis': 'sdsssf', 'text': 'we', 'autor': 'e', 'publikovanoDne': '2023-03-08T00:00:00', 'publikovanoDo': '2023-03-17T00:00:00', 'vytvorenoDne': '2023-03-20T00:00:00', 'proPrihlasene': true, 'priloha': 'e', 'poradi': 'w', 'typClanku': 5 }
        //        , { 'id': '449b1c96-6284-4fde-7e7c-08db223d9ced', 'nadpis': 'sdf', 'text': 'we', 'autor': 'e', 'publikovanoDne': '2023-03-08T00:00:00', 'publikovanoDo': '2023-03-17T00:00:00', 'vytvorenoDne': '2023-03-20T00:00:00', 'proPrihlasene': true, 'priloha': 'e', 'poradi': 'w', 'typClanku': 5 }
        //    ]
  

    },
 
    mounted() {

        console.log('mounted')

        axios
            .get(`/Clanek/Prehled`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        nadpis: res.data[i].nadpis,
                        text: res.data[i].text,
                    };
                this.clanky.push(newItem);
                }
            })





     
    },
    beforeCreate: function () {

    },
}