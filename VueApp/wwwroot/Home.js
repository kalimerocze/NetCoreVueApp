const Home = {
    template: `
   <div>
           <v-container class="grey lighten-5">
 
            <v-row no-gutters>
                <v-col cols="12"sm="12">
                    <v-card class="pa-2" outlined tile>
                        <h1>Přehled novinek</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <v-btn to='/prehledNovinek'>Novinky</v-btn>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        </br>


        <v-container class="grey lighten-5">
            <v-row no-gutters>
                <v-col cols="12"sm="6">
                    <v-card class="pa-2" outlined tile>
                        <h1>Přehled článků</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <v-btn to='/about'>O nás</v-btn>
                    </v-card>
                </v-col>
                <v-col cols="12" sm="6">
                    <v-card class="pa-2" outlined tile>
                        <h1>Kontakty</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <v-btn to='/kontakt'>Kontakty</v-btn>
                    </v-card>
                </v-col>
            </v-row>
            <br>
            <v-row no-gutters>
                <v-col cols="12"sm="12">
                    <v-card class="pa-2" outlined tile>
                        <h1>Třetí kartička Init{{text}}</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <v-btn to='/soubor'>Soubor</v-btn>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </div>
`,
    data() {
        return {
            text: 'Domů',
            isEnable: false
        }
    },
    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        }
    },
    created() {
        window.document.title = 'Hl. stránka - Vue'
    }
}