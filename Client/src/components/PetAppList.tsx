// A '.tsx' file enables JSX support in the TypeScript compiler, 
// for more information see the following page on the TypeScript wiki:
// https://github.com/Microsoft/TypeScript/wiki/JSX
import * as React from 'react';
import {PetsApi} from '../actions/PetsApi';
import {PetType} from '../models/petType'

class PetAppList extends React.Component<any, any>{
    constructor(props) {
        super(props);
        this.state = {
            items:  []
        }
    }    

    componentDidMount() {           
        var currentComponent = this;        
        PetsApi.GetPetSummary(PetType.Cat).then(function (response) {            
            currentComponent.setState({
                items: response
            });
        })
        .catch(function (error) {
            console.log(error);
        });                
    }

    render() {                    
        return (
                <div>
                    {
                        this.state.items.map((childItem, key) =>
                            <div>                                
                                {childItem.genderType}                                
                                    <div>                                    
                                    {   
                                        childItem.pets.map((pet, key) => 
                                        <div>
                                           -  {pet.name}
                                        </div>
                                        )
                                    }                                
                                </div>
                            </div>
                        )                    
                    }
                </div>
            );
    }
}

export default PetAppList;
