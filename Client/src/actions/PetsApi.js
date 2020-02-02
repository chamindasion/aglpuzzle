import Axios from 'axios';

let PetsApi = {
    getPetSummary(){         
       //TODO: read url from config 
        return Axios(petApiUrl, {
            method: 'GET',
            headers: {
              'Access-Control-Allow-Origin': '*',
              'Content-Type': 'application/json',
            },
          }).then(response => {            
            console.log('All posts: ', response.data)
            var responseData = response.data;            

            return responseData;
          })
    }    
}

export default PetsApi;
