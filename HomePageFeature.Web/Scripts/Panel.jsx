var Elements = {
  Text: "TextElement",
  Image: "ImageElement",
    Button: "ButtonElement"
};

var TextElement = React.createClass({

    componentDidMount : function(){
        CKEDITOR.inline(this.id);
    },
  render: function() {
        var converter = new Showdown.converter();
        var rawMarkup = converter.makeHtml("<div></div > ");
        if (this.props.data && this.props.data.Html) {
      rawMarkup = converter.makeHtml(this.props.data.Html.toString());
    }

    console.log("rawMarkup", rawMarkup);
        this.id = "editor"+Math.floor(Math.random()*1000);
    return (
      <div id={this.id} contentEditable={true} className="my-class" dangerouslySetInnerHTML={{__html: rawMarkup}}></div>
    )
  }
});

var ImageElement = React.createClass({
  render: function() {
    return (
            <div>
          <img src={this.props.data.Source} alt={this.props.data.Alt} />
                <div>{this.props.data.Caption}</div>
            </div>
            )
    }
});

var ButtonElement = React.createClass({
  render: function() {
    return (
      <a href={this.props.data.Href}>{this.props.data.Text}</a>
            )
    }
});

var ElementsRenderer = (function(){
    var renderElements = function(contentContainers, elements){
        for(var i in contentContainers){
            if(elements[i] && elements[i].Type && Elements[elements[i].Type]){
                console.log("elementsToRender", Elements[elements[i].Type]);
                console.log("contentcontainer", $(contentContainers[i])[0]);
                ReactDOM.render(
                    React.createElement(window[Elements[elements[i].Type]], { data : elements[i].Content}),
                    $(contentContainers[i])[0]);
            }
        }
    }
    return {
        renderElements : renderElements
    }
})();
﻿var PanelBasicInfo = React.createClass({
    render : function(){
        return (
            <div>
                <label>name:</label>
                <input type="text" value={this.props.data.Name}/>
            </div>
        )
    }
});


var PanelContent = React.createClass({
    renderElements: function(){
        var contents = $("div[data-feature-name|=content]");
        console.log("contents", contents);
        if(contents && contents.length > 0){
            ElementsRenderer.renderElements(contents, this.props.data.Elements)
        }
    },
    componentDidUpdate: function(){
        //validate if there are elements to render
        if(this.props.data && this.props.data.Elements){
            this.renderElements();
        }
    },
    render: function(){
        var converter = new Showdown.converter();
        var rawMarkup = converter.makeHtml("<div></div > ");
        if (this.props.data && this.props.data.Layout) {
      rawMarkup = converter.makeHtml(this.props.data.Layout.Content.toString());
    }
    console.log("rawMarkup", rawMarkup);
    return (
      <span className="my-class" dangerouslySetInnerHTML={{__html: rawMarkup}}/>
    )
  }
});

var PanelElements = React.createClass({
  render: function() {
    return (
      <div>render elements here</div>
    )
  }
});

var PanelContainer = React.createClass({
  getInitialState: function() {
    return {
      data: [],
      panelId: this.props.initialPanelId
    };
  },
  panelIdChange: function(event){
    console.log("panelid change", event.target.value);
    this.setState({ panelId: event.target.value });
  },

  loadCommentsFromServer: function() {
    console.log("state", this.state);
    var panelId = this.state.panelId;
        var xhr = new XMLHttpRequest();
    xhr.open('get', this.props.url + panelId, true);
        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        xhr.setRequestHeader("Accept", "application/json");
    xhr.onload = function() {
      var data = JSON.parse(xhr.responseText);
      this.setState({data: data});
    }.bind(this);
    xhr.send();
  },
  componentDidMount: function() {
    this.loadCommentsFromServer();
  },
  render: function() {
    return (
      <div>
        <div>
          <input type="number" value={this.state.panelId} onChange={this.panelIdChange} />
          <input type="button" value="render" onClick={this.loadCommentsFromServer} />
        </div>
        <PanelBasicInfo data={this.state.data}></PanelBasicInfo>
        <PanelElements></PanelElements>
        <PanelContent data={this.state.data}></PanelContent>
      </div>
    );
  }
});

ReactDOM.render(
  <PanelContainer url="/api/panel/" initialPanelId="1"/>, document.getElementById('panel')
);
