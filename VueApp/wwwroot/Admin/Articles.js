const Articles = {
    template: `
    <div>
        <v-form  id="form" name="idForm">
            <v-container>
                <v-alert dismissible v-model="showMsg" :color="colorMsg" outlined :type="typeMsg">
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode="out-in">
                    <v-layout column align-start>
                        <h1 class="display-1">Sekce administrace clanků <br /><br /></h1>
                        Administrace článků
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Title"placeholder="Title" v-model="Article.title"></v-text-field>
                                    <v-text-field label="Author" placeholder="Author" v-model="Article.author"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Article.text"></v-text-field>
                                    <v-date-picker v-model="Article.publishedOn"></v-date-picker>
                                    <v-date-picker v-model="Article.publishedTo"></v-date-picker>
                                    <v-date-picker v-model="Article.createdOn"></v-date-picker>
                                    <label for="forLoggedUserOnly">For logged users only:</label>
                                    <v-checkbox name = "forLoggedUserOnly" v-model="Article.forLoggedUserOnly"></v-checkbox>
                                    <v-text-field label="Attachment" placeholder="Attachment" v-model="Article.attachment"></v-text-field>
                                    <v-text-field label="Order" placeholder="Order" v-model="Article.order"></v-text-field>
                                    <v-text-field type="number" label="Type" placeholder="Type" v-model="Article.type"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitForm">Submit form</v-btn>
                                    <v-btn color='purple' style='color:white;' type="button" text @click="clear"> Clear form</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
            </v-container>
        </v-form>
    </div>
    `,


    data() {
        return {
            text: 'Articles',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Article: {
                //id:'',
                title: '',
                text: '',
                author: '',
                publishedOn: '',
                publishedTo: '',
                createdOn: '',
                forLoggedUserOnly: false,
                attachment: '',
                order: '',
                type: null,


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
        submitForm: function () {
            console.log(this.Article.text);
            let formData = new FormData();
            if (this.Article) {
                var self = this;
                axios.post('/Article/Add', this.Article,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        self.showMsg= true;
                        self.colorMsg = 'green';
                        self.typeMsg = 'success';
                        self.resultMsg = 'Upload successful!';
                        

                    }).catch(function (error) {
                        self.showMsg = true;
                        self.colorMsg = 'red';
                        self.typeMsg = 'error';
                        self.resultMsg = 'An error has occurred!';

                    })
                this.$refs.entryForm.reset()


            }
            else {
                this.showMsg = true;
                this.colorMsg = 'yellow';
                this.typeMsg = 'warning';
                this.resultMsg = 'Not seleted any file!';

            }
        }
    },
    created() {
        window.document.title = 'Articles form - Vue'
    }
}