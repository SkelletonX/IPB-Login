<?php
    $servidor = "localhost";
    $usuario = "root";
    $senha = "123456";
    $dbname = "ipb_Forum";
    
    //Criar a conexao
    $conn = mysqli_connect($servidor, $usuario, $senha, $dbname);
    
    if(!$conn){
        die("Falha na conexao: " . mysqli_connect_error());
    }else{
        //echo "Conexao realizada com sucesso \n";
    }      
?>