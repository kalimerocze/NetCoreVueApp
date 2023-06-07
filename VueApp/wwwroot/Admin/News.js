const News = {
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
                        <h1 class="display-1">News administration <br /><br /></h1>
                        Nwes administration
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Title"placeholder="Title" v-model="News.title"></v-text-field>
                                    <v-text-field label="Author" placeholder="Author" v-model="News.author"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="News.text"></v-text-field>
                                    <label for="publishedOn">Published on</label>
                                    <v-date-picker name="publishedOn" v-model="News.publishedOn"></v-date-picker><br>
                                    <label for="publishedTo">Published to</label>
                                    <v-date-picker name="publishedTo" v-model="News.publishedTo"></v-date-picker><br>
                                    <label for="createdOn">Created on</label>
                                    <v-date-picker name="createdOn" v-model="News.createdOn"></v-date-picker><br>
                                    <label for="forLoggedUserOnly">For logged users only:</label>
                                    <v-checkbox name="forLoggedUserOnly" v-model="News.forLoggedUserOnly"></v-checkbox>
                                    <v-text-field label="Attachment" placeholder="Attachment" v-model="News.attachment"></v-text-field>
                                    <v-text-field label="Order" placeholder="Order" v-model="News.order"></v-text-field>
                                    <v-text-field type="number" label="Type" placeholder="Type" v-model="News.type"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn  style='color:white;' color="success" type="button" text @click="submitForm">Submit form</v-btn>
                                    <v-btn  style='color:white;'color='purple' type="button" text @click="clear">Clear form</v-btn>
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
            text: 'News',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            News: {
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
            let formData = new FormData();
            if (this.News) {
                var self = this;

                axios.post('/News/Add', this.News,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        self.showMsg = true;
                        self.colorMsg = 'green';
                        self.typMsg = 'sucess';
                        self.resultMsg = 'Upload successful!';
                    }).catch(function (error) {
                        self.showMsg = true;
                        self.colorMsg = 'red';
                        self.typMsg = 'error';
                        self.resultMsg = 'An error has been occurred!';
                    })
                this.$refs.entryForm.reset()

            }
            else {
                this.showMsg = true;
                this.colorMsg = 'yellow';
                this.typMsg = 'warning';
                this.resultMsg = 'Not selected any file!';
            }
        }
    },
    created() {
        window.document.title = 'News form - Vue'
    }
}