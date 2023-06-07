const Category = {
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
                        <h1 class="display-1">Category administration <br /><br /></h1>
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Title"placeholder="Title" v-model="Category.title"></v-text-field>
                                    <v-text-field label="Description" placeholder="Description" v-model="Category.description"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn  color="success" type="button" text @click="submitForm">Submit form</v-btn>
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
            text: 'Category',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            Category: {
                //id:'',
                title: '',
                description: '',
                

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
            if (this.Category) {
                var self = this;

                axios.post('/Category/Add', this.Category,
                    {
                        headers: {
                            'Content-Type': 'application/json'
                        }
                    }).then(function (response) {
                        self.showMsg = true;
                        self.colorMsg = 'green';
                        self.typMsg = 'sucess';
                        self.resultMsg = 'Uplaod successful!';
                    }).catch(function (error) {
                        self.showMsg = true;
                        self.colorMsg = 'red';
                        self.typMsg = 'error';
                        self.resultMsg = 'An error has occurred!';
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
        window.document.title = 'Category form - Vue'
    }
}