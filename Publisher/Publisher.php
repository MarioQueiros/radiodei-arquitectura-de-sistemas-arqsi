<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <title>Publisher</title>
        <link rel="stylesheet" type="text/css" href="Publisher.css" />
        <script src="jquery-1.8.2.min.js"></script>
<script>

function listMusics(name)
{
	var plm = document.getElementById("list");
    var option = document.createElement("option");
    var optiontext = document.createTextNode(name);
    option.appendChild(optiontext);
    plm.appendChild(option);
}
		
function addMusics(form,sourceID,source2ID,targetID,target2ID) 
{
	source=document.getElementById(sourceID)
	source2=document.getElementById(source2ID)
	target=document.getElementById(targetID)
	target2=document.getElementById(target2ID)
	warning(form);
	if(form.input.value != "" && form.input2.value != ""){
		var year = parseInt(form.input2.value );
		var pattern = /^[0-9]{4}$/;
		if(pattern.test(year)){
			if (target.value=='' && form.input.value!=""){
				var str = form.input.value.replace('&', '@');
				target.value = str
				target2.value=form.input2.value
				listMusics(form.input.value);
			}
			else{
				if(form.input.value!=""){
					var str = form.input.value.replace('&', '@');
					target.value += ';' + str
					target2.value += ';' + form.input2.value
					listMusics(form.input.value);
				}
			}
			source.value = ''
			source2.value = ''
		}
		else{
			document.getElementById('warning').innerHTML  = "Add a valid year!";
			document.getElementById('warning').style.visibility = "visible";
		}
	}
}

function warning(form)
{
	if (form.input2.value=="" && form.input.value==""){
		document.getElementById('warning').style.visibility = "visible";
	}
	else if (form.input.value==""){
		document.getElementById('warning').innerHTML  = "Add music!";
		document.getElementById('warning').style.visibility = "visible";
	}
	else if (form.input2.value==""){
		document.getElementById('warning').innerHTML  = "Add year!";
		document.getElementById('warning').style.visibility = "visible";
	}
	else{
		document.getElementById('warning').style.visibility = "hidden";
		document.getElementById('warning2').style.visibility = "hidden";
	}
}

function sentMusics()
{
	var str = document.mainform.output.value;
	if (str==""){
		document.getElementById('warning2').style.visibility = "visible";
	}
	else{
		document.getElementById('warning2').style.visibility = "hidden";
		link = 'Publisher.php?musics=' + document.mainform.output.value +"|"+ document.mainform.output2.value
		window.location = link
	}
}

</script>
</head>
<body>
	<img src="images.jpg"	id="full-screen-background-image" />
	<div>
	<h1 class="title">Publisher</h1>
	</div>
	<div class="form-container">
	<form name="mainform">
		Name:<input class="form-field" type="text" id="input" name="input"><br>
		Year:<br/><input class="form-field" type="text" id="input2" name="input2"><br>
		<div class="submit-container">
			<input class="submit-button" name="add" type="button" onClick="addMusics(this.form,'input','input2','output','output2')" value="Add Music!">
		</div>
		<div class="form-title">
			<label id="warning" class="hidden">Add a music and year!</label>
		</div>
		<br><br>
		<select class="combobox" name="list" id="list" size="10" style="min-width:150px"></select><br>
		<input type="hidden" id="output" name="output">
		<input type="hidden" id="output2" name="output2">
		<div class="submit-container">
			<input class="submit-button" name="send" type="button" onClick="sentMusics()" value="Sent Musics!"><br>
		</div>
		<div class="form-title">
			<label id="warning2" class="hidden">You have to add musics!</label>
		</div>
	</form>
	</div>
</body>
</html>

<?php
try {  
	$client= new SoapClient
 		('http://wvm036.dei.isep.ipp.pt:64899/iRadioDeiService.svc?wsdl');

	if(isset($_GET['musics'])){
		$musics = $_GET['musics']; 
		$musicArray1 = explode('|',$musics);
		$musicsArray2 = explode(';',$musicArray1[0]); 
		$musicsCount = substr_count($musicArray1[0],';'); 
		if($musicsArray2[0]!=''){
			echo '<div class="list-container"><div class=form-list>';
			echo '<b>You sent this musics:</b><ul>';
			for ($i=0 ; $i<=$musicsCount ; $i++) 
			{ 
				$music = str_replace("@", "&",$musicsArray2[$i]);
				echo '<li>'; 
				echo $music;
				echo '</li>';
			}  
			echo '</ul></div></br>';
			$txt = $musicArray1[0] . "|" . $musicArray1[1];
			$result=$client->getMusics(array('data' => $txt));
		}
	}
} catch (Exception $e) {  
	echo '<div class="list-container"><b>The server is down for maintenance. Try again later.
		</br>We appreciate your understanding.</b></div>';
}
?>