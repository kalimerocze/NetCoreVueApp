const Links = {
    template: `
  <div>
        <v-form ref="entryForm" id="form" name="idForm">
            <v-container>
                <v-alert dismissible v-model="showMsg" :color="colorMsg" outlined :type="typeMsg">
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode="out-in">
                    <v-layout column align-start>
                        <h1 class="display-1">Link administration<br /><br /></h1>
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Url" placeholder="Url" v-model="Link.url"></v-text-field>
                                    <v-text-field label="Text" placeholder="Text" v-model="Link.text"></v-text-field>
                                    <v-text-field label="Description" placeholder="Description" v-model="Link.description"></v-text-field>
                                    <v-text-field label="Type" placeholder="Type" v-model="Link.type" type="number"></v-text-field>
                                    <v-text-field label="Group of links" placeholder="Group of links" v-model="Link.groupOfLinks"></v-text-field>
                                    <v-text-field label="Block of links" placeholder="Block of links" v-model="Link.blockOfLinks"></v-text-field>
                                    <v-text-field label="Order" placeholder="Order" v-model="Link.order" type="number"></v-text-field>
                                    <label for="published">Published:</label>
                                    <v-checkbox name="published" v-model="Link.published"></v-checkbox>
                                    <label for="openToNewWindow">Open to new window:</label>
                                    <v-checkbox name="openToNewWindow" v-model="Link.openToNewWindow"></v-checkbox>
                                    <label for="forLoggedUserOnly">For logged users only:</label>
                                    <v-checkbox name="forLoggedUserOnly" v-model="Link.forLoggedUserOnly"></v-checkbox>
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitForm">Submit form</v-btn>
                                    <v-btn color='purple' style='color:white;' type="button" text @click="clear">Clear form</v-btn>
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
            text: 'Links',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Link: {
                //id:'',
                url: '',
                text: '',
                description: '',
                type: '',
                groupOfLinks: '',
                blockOfLinks: '',
                order: '',
                published: false,
                openToNewWindow: false,
                forLoggedUserOnly: false,


            },
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
            if (this.Link) {
            
                axios.post('/Link/Add', this.Link,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        this.showMsg = true;
                        this.colorMsg = 'green';
                        this.typMsg = 'sucess';
                        this.resultMsg = 'Upload successful!';
                    }).catch(function (error) {
                        this.showMsg = true;
                        this.colorMsg = 'red';
                        this.typMsg = 'error';
                        this.resultMsg = 'An error ahs been occurred!';
                    })
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
        window.document.title = 'Links form - Vue'
    }
}