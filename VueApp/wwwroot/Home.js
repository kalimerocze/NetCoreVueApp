const Home = {
    template: `
  <div>
        <v-container class='grey lighten-5'>
            <v-row no-gutters>
                <v-col cols='12' sm='12'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>List of news</h1>
                        <div v-for='item in news' :key='item.id'>
                            <v-card >
                                <h1 class=' blue-grey lighten-3 white--text text-center'>{{ item.title }}</h1>

                                <p> {{ item.text }}</p>
                                        

                            </v-card>
                        </div>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
        </br>


        <v-container class='grey lighten-5'>
            <v-row no-gutters>
                <v-col cols='12' sm='6'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>List of articles</h1>
                        
                        <div v-for='article in articles' :key='article.id'>
                            <v-card width='400'>
                                <h1 class='blue-grey lighten-3 white--text text-center'>{{ article.title }}</h1>

                                <p> {{ article.text }}</p>
                                <p> {{ article.author }}</p>
                                <p> {{ article.publishedTo }}</p>

                            </v-card>
                        </div>

                    </v-card>
                </v-col>
                <v-col cols='12' sm='6'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>List of links</h1>
                      
                        <div v-for='link in links' :key='link.id'>
                            <v-card width='400'>
                                <h1 class='blue-grey lighten-3 white--text text-center'>{{ link.description }}</h1>

                                <p> {{ link.text }}</p>
                                <p> {{ link.description }}</p>


                            </v-card>
                        </div>
                    </v-card>
                </v-col>
                <v-col cols='12' sm='12'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'>Contacts</h1>
                        
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

                                    </tr>
                                </thead>
                                <tbody>
                                    <tr v-for="item in contacts" :key="item.id">
                                        <td>{{ item.name }}</td>
                                        <td>{{ item.surname }}</td>
                                        <td>{{ item.phone }}</td>
                                        <td> <span :class="item.active? 'mdi mdi-check green--text':'mdi mdi-cancel red--text'"></span>     </td>
                                        <td>{{ item.city }}</td>
                                    </tr>
                                </tbody>
                            </template>
                        </v-simple-table>
                    </v-card>
                </v-col>
            </v-row>
            <br>
            <v-row no-gutters>
                <v-col cols='12' sm='12'>
                    <v-card class='pa-2' outlined tile>
                        <h1 class='grey darken-2 white--text text-center'> Uploaded files </h1>
                        <button @click='toggle'>Toggle Show / Hide Other text</button>
                        <br><br>
                        <h2 v-if='isEnable'>To be defined !</h2>
                        <v-btn color='purple' style='color:white;' to='/FileSummary'>Files</v-btn>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </div>
`,
    data() {
        return {
            text: 'Home',
            isEnable: false,
            articles: [],
            news: [],
            links: [],
            contacts: [],

        }
    },
    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        }
    },
    created() {
        window.document.title = 'Main page - Vue'
    },
    mounted() {

        console.log('mounted')
        axios
            .get(`/Link/Summary`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        description: res.data[i].description,
                        text: res.data[i].text,
                        publishedTo: res.data[i].publishedTo,
                    };
                    this.links.push(newItem);
                }
            })

        axios
            .get(`/News/Summary`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        title: res.data[i].title,
                        text: res.data[i].text,
                        author: res.data[i].author,
                    };
                    this.news.push(newItem);
                }
            })

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



        axios
            .get(`/Article/Summary`)
            .then(res => {
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        title: res.data[i].title,
                        text: res.data[i].text,
                        author: res.data[i].author,
                        publishedTo: res.data[i].publishedTo,
                    };
                    this.articles.push(newItem);
                }
            })
    },
}