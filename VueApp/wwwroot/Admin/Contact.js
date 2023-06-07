const Contact = {
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
                        <h1 class="display-1">Contact administration <br /><br /></h1>
                        Administrace novinek
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-text-field label="Name"placeholder="Name" v-model="Contact.name"></v-text-field>
                                    <v-text-field label="Surname" placeholder="Surname" v-model="Contact.surname"></v-text-field>
                                    <v-text-field label="Phone" placeholder="Phone" v-model="Contact.phone"></v-text-field>
                                    <label for="active">Active:</label>
                                    <v-checkbox name="active" v-model="Contact.active"></v-checkbox>
                                    <v-text-field label="City" placeholder="City" v-model="Contact.city"></v-text-field>
                                </v-flex>
                                <v-flex>
                                    <v-btn  style='color:white;' color="success" type="button" text @click="submitForm">Submit form</v-btn>
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
            text: 'Contacts',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            kontakty: [
                { id: 1, name: 'Petr', surname: 'Pavel', phone :'444222111'},
                { id: 2, name: 'Marek', surname: 'Novák', phone: '444222111' },
                { id: 3, name: 'Radek', surname: 'Novák', phone: '444222111' },
                { id: 4, name: 'Kateřina', surname: 'Nováková', phone: '444222111' }
        ],
            Contact: {
                //id:'',
                name: '',
                surname: '',
               phone:'',
               city:'',
               active:true,


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
            var self = this;

            let formData = new FormData();
            if (this.Contact) {
                axios.post('/Contact/Add', this.Contact,
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
        window.document.title = 'Contact form - Vue'
    }
}