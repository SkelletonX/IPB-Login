<?php
    //?name=USUARIO&senha=SENHA_DO_USUARIO
	session_start(); 
	include_once("conexao.php");
			
	$usuario = mysqli_real_escape_string($conn, $_GET['name']);
	$senha = mysqli_real_escape_string($conn, $_GET['senha']);
	
	$result_usuario = "SELECT * FROM members WHERE name = '$usuario'";
	$resultado_usuario = mysqli_query($conn, $result_usuario);
	$resultado = mysqli_fetch_assoc($resultado_usuario);
			
	$salt = $resultado['members_pass_salt'];
				
	$senhaw = md5(md5($salt) . md5($senha));
			
	$result_usuario2 = "SELECT * FROM members WHERE members_pass_hash = '$senhaw'";
	$resultado_usuario2 = mysqli_query($conn, $result_usuario2);
	$resultado2 = mysqli_fetch_assoc($resultado_usuario2);
			
			
	if(isset($resultado2)){
				echo "Login_OK";

	}else{
			echo "Dados_incorretos";
	} 
	
?>