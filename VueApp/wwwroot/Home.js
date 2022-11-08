const Home = {
    template: `
   <div>
        <v-container class="grey lighten-5">
            <v-row no-gutters>
                <v-col cols="12"sm="6">
                    <v-card class="pa-2" outlined tile>
                        <h1>home page...... Init{{text}}</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <a href='/about'>About page</a>
                    </v-card>
                </v-col>
                <v-col cols="12" sm="6">
                    <v-card class="pa-2" outlined tile>
                        <h1>home page...... Init{{text}}</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <a href='/about'>About page</a>
                    </v-card>
                </v-col>
            </v-row>
            <br>
            <v-row no-gutters>
                <v-col cols="12"sm="12">
                    <v-card class="pa-2" outlined tile>
                        <h1>home page...... Init{{text}}</h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>Pee nadpis !</h2>
                        <a href='/about'>About page</a>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </div>
`,
    data() {
        return {
            text: 'Home',
            isEnable: false
        }
    },
    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        }
    },
    created() {
        window.document.title = 'Home - Vue'
    }
}