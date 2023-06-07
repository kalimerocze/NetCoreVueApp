const FileSummary = {
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
                        <h1 class="display-1">Files summary <br /><br /></h1>
                                     <v-simple-table dense  style='width:100vw;'>
                     <thead>
      <tr>
        <th class="text-left">
          Id
        </th>
        <th class="text-left">
          File name
        </th>
        <th class="text-left">
          Folder
        </th>
        <th class="text-left">
          Action
        </th>
        
      </tr>
    </thead>
    <tbody>
      <tr
        v-for='item in files'
        :key='item.id'>
    
        <td>{{ item.id }}</td>
        <td>{{ item.fileName }}</td>
        <td>{{ item.folder }}</td>
  <td> <v-btn color='purple' style='color:white;' type='button' @click='deleteItem($event, item.id)'> Delete</v-btn> </td>
      </tr>
    </tbody>
  </v-simple-table >
                    </v-layout>
                </v-slide-y-transition>
                <v-btn color='purple' style='color:white;' type="button" @click="clear"> Clear from </v-btn>
            </v-container>
        </v-form>
    </div>

    `,
    data() {
        return {
            text: 'All files',
            isEnable: false,
            colorMsg: 'red',
            typeMsg: 'success',
            files: [
                //{ id: 1, nazevSouboru: 'test.txt', slozkaSouboru: 'http//:...' },
                //{ id: 2, nazevSouboru: 'tets1.txt', slozkaSouboru: 'http//:...' },
                //{ id: 3, nazevSouboru: 'tets2.txt', slozkaSouboru: 'http//:...' }


            ],

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
            this.files = []
            this.$refs.entryForm.reset()

        },
        deleteItem: function (event, id) {
            // use event here as well as id
            console.log(id)
            var self = this;
    
            axios
                .delete(`/File/DeleteFile/` + id)
                .then(res => {
                    self.showMsg = true;
                    self.colorMsg = 'green';
                    self.typMsg = 'sucess';
                    self.resultMsg = 'File has been deleted successfully!';
                })

        }
    },
    created() {
        window.document.title = 'All available files '
    },
    mounted() {

        console.log('mounted')

            console.log("calling api")
        axios
            .get(`/File/GetFiles`)
            .then(res => {
            console.log("calling api")
            console.log(res)
                for (let i = 0; i < res.data.length; i++) {

                    var newItem = {
                        id: res.data[i].id,
                        fileName: res.data[i].fileName,
                        folder: res.data[i].folder,
                    };
                    this.files.push(newItem);                  
                }
            })
    },
}