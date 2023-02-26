const Upload = {
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
                        <h1 class="display-1">Server1 externích informačních zdrojů </h1><br><br >
                        Import souborů <br />Vyberte xml soubor.
                        <v-form class="block" ref="entryForm">
                            <v-container>
                                <v-flex>
                                    <v-file-input show-size chips multiple label="Vyberte prosím soubor.." ref="formFiles" v-model="formFiles"></v-file-input>
                                </v-flex>
                                <v-flex>
                                    <v-btn color="success" type="button" text @click="submitFiles">Odeslat</v-btn>
                                </v-flex>
                            </v-container>
                        </v-form>
                    </v-layout>
                </v-slide-y-transition>
                <v-btn type="button" @click="clear"> Resetovat </v-btn>
            </v-container>
        </v-form>
    </div>
    `,
    data() {
        return {
            text: 'Upload',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            formFiles: null,
            showMsg: false,
            resultMsg: '',
            dialog: false,
        }
    },
    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        }
    },
    created() {
    //nazevv tabu
        window.document.title = 'Upload formulář - Vue'
    }
}