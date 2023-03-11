const prehledClanky = {
    template: `
    <div>
            <v-container>
                <v-alert dismissible v-model="showMsg" :color="colorMsg" outlined :type="typeMsg">
                    <div d-flex justify-start>
                        {{resultMsg}}
                    </div>
                </v-alert>
                <v-slide-y-transition mode="out-in">
                    <v-layout column align-start>
                        <h1 class="display-1">Přehled článků <br /><br /></h1>
                    <div v-for="novinka in clanky"
        :key="novinka.id">
                           <v-card width="400">
      <h1>{{ novinka.nadpis }}</h1>

    <p> {{ novinka.text }}</p>
<p> {{ novinka.text }}</p>
<p> {{ novinka.autor }}</p>
<p> {{ novinka.publikovanodo }}</p>
<p> {{ novinka.publikovanodne }}</p>
<p> {{ novinka.proprihlasene }}</p>
<p> {{ novinka.priloha }}</p>
<p> {{ novinka.poradi }}</p>
<p> {{ novinka.typclanku }}</p>

    </v-card>
    </div>

              


                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> clear</v-btn>
            </v-container>
    </div>
    `,
    data() {
        return {
            text: 'Články',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
        //    clanky: [
        //        { id: 1, nadpis: 'nadpis1', text: 'clanek 1 '},
        //        { id: 2, nadpis: 'nadpis 2 ', text: 'clanek 2'},
        //        { id: 3, nadpis: 'nadpis3 ', text: 'clanek 3'}


        //],


            showMsg: false,
            resultMsg: '',
            dialog: false,
        }
    },
    props: {
        // type check
        height: Number,
        // type check plus other validations
        clanky: []
    },


    methods: {
        toggle() {
            this.isEnable = !this.isEnable
        },
        clear() {
            this.$refs.entryForm.reset()

        },
    },
    created() {
        console.log('created')

        window.document.title = 'Kontakty form - Vue';

    },
 
    mounted: function () {
        console.log('mounted')
     

        axios.get('/Clanek/Prehled',
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(function (response) {
                console.log(response)
                
                for (let i = 0; i < response.data.length; i++) {
                    console.log(response.data[i]);
                    //clanky.push(response.data[i]);
                    //console.log(clanky)
                    props.clanky.push(response.data[i])
                    
                }
                console.log('test')
                console.log(props.clanky)
                console.log('test')
                //console.log(prehledClanky)
                this.showMsg = true;
                this.colorMsg = 'green';
                this.typMsg = 'sucess';
                this.resultMsg = 'Upload proběhl úspěšně!';
            }).catch(function (error) {
                this.showMsg = true;
                this.colorMsg = 'red';
                this.typMsg = 'error';
                this.resultMsg = 'Nastala chyba!';
            })
     
    },
    beforeCreate: function () {

    },
}