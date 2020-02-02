import * as React from "react";
import * as ReactDOM from "react-dom";
import PetApp from "./components/PetApp";

class Main extends React.Component<any,any>{
    
    constructor(props: any) {                
        super(props);        
    }

    render(){
        return (   
            <div>
                <div>        
                    <h2>Pet Summary</h2>
                </div>                 
                <div> 
                    <PetApp/>
                </div>
            </div>
        );
    }
}
 
ReactDOM.render(<Main/>, document.getElementById("main"));


  


