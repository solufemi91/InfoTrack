import React from 'react';

class formComponent extends React.Component {

    constructor(props) {
        super(props);
    }

    render() {
        return (
            <form id="myForm">
                <label htmlFor="Keywords">Keywords:</label>
                <input type="text" id="Keywords" name="Keywords"></input><br></br>

                <label htmlFor="Url">Url:</label>
                <input type="text" id="Url" name="Url"></input><br></br>

                <button type="button" onClick={this.props.search}>Search</button>
                <div id="resultsBoxContainer" style={{ display: this.props.numberPositions ? "block" : "none" }}>
                    <h4>Results Box:</h4>
                    <div id="resultsBox">{this.props.numberPositions}</div>
                </div>
               
            </form>
        );
    }

}

export default formComponent;