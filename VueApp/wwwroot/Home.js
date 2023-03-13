const Home = {
    template: `
   <div>
           <v-container class='grey lighten-5'>
 
            <v-row no-gutters>
                <v-col cols='12'sm='12'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center' >Přehled novinek</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                  <div   v-for='novinka in novinky'
        :key='novinka.id'>
                           <v-card width='400'>
      <h1  class=' blue-grey lighten-3 white--text text-center'>{{ novinka.nadpis }}</h1>

    <p> {{ novinka.text }}</p>


    </v-card>
    </div>                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        </br>


        <v-container class='grey lighten-5'>
            <v-row no-gutters>
                <v-col cols='12'sm='6'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>Přehled článků</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                                          <div  v-for='clanek in clanky'
        :key='clanek.id'>
                           <v-card width='400'>
      <h1 class='blue-grey lighten-3 white--text text-center'>{{ clanek.nadpis }}</h1>

    <p> {{ clanek.text }}</p>

    </v-card>
    </div>

                    </v-card>
                </v-col>
  <v-col cols='12'sm='6'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>Přehled odkazů</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
               <div  v-for='odkaz in odkazy'
        :key='odkaz.id'>
                           <v-card width='400'>
      <h1 class='blue-grey lighten-3 white--text text-center'>{{ odkaz.popis }}</h1>

    <p> {{ odkaz.text }}</p>


    </v-card>
    </div>                    </v-card>
                </v-col>
                <v-col cols='12' sm='6'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>Kontakty</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <v-btn color='purple' style='color:white;' to='/kontakt'>Kontakty</v-btn>
                    </v-card>
                </v-col>
            </v-row>
            <br>
            <v-row no-gutters>
                <v-col cols='12'sm='12'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'> Přehled souborů v úložišti</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <v-btn color='purple' style='color:white;' to='/prehledSouboru'>Soubory</v-btn>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </div>
`,
    data() {
        return {
            text: 'Domů',
            isEnable: false,
            clanky: [],
            novinky: [],
            odkazy: [],

        }
    },
    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        }
    },
    created() {
        window.document.title = 'Hl. stránka - Vue'
    },
    mounted() {

        console.log('mounted')
        axios
            .get(`/Odkaz/Prehled`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        popis: res.data[i].popis,
                        text: res.data[i].text,
                    };
                    this.odkazy.push(newItem);
                }
            })

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

}