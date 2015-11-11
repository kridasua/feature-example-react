
var PanelBasicInfo = React.createClass({

	render:function(){
		return (
			<div>
                <label>name:</label>
                <input type="text" value={this.props.Name} />
            </div>
		)
	}
});


var PanelContent = React.createClass({	


	render: function(){
		var converter = new Showdown.converter();
		var rawMarkup = converter.makeHtml("<div></div>");
		if(this.props.data && this.props.data.Layout){
			rawMarkup = converter.makeHtml(this.props.data.Layout.Content.toString());
		}    	
		console.log("rawMarkup", rawMarkup);
		return (		

			<span class="my-class" dangerouslySetInnerHTML={{__html: rawMarkup}} />
			)
	}
});

var PanelElements = React.createClass({	
	render: function(){
		
		return (
			<div>render elements here</div>
			)
	}
});


var PanelContainer = React.createClass({
    getInitialState: function() {
	    return {data: []};
	},

    loadCommentsFromServer: function(){  
	    var xhr = new XMLHttpRequest();
	    xhr.open('get', this.props.url, true);
	    xhr.onload = function() {
	      var data = JSON.parse(xhr.responseText);
	      this.setState({ data: data });
	    }.bind(this);
	    xhr.send();  
    },
    componentDidMount: function() {
        this.loadCommentsFromServer();	    
    },
    render: function(){
        return (
            <div>
            	<PanelBasicInfo data={this.state.data}></PanelBasicInfo>
                <PanelElements></PanelElements>
                <PanelContent data={this.state.data}></PanelContent>
            </div> 
            );
    }
});


React.render(
     <PanelContainer url="/api/panel/1" />,
     document.getElementById('panel')
);