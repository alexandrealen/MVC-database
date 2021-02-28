Atenção: Para o funcionamento correto do projeto, é necessária a criação de uma tabela sqlServer a partir do seguinte script:

    CREATE TABLE Goiabinha
    (
		id INT PRIMARY KEY IDENTITY,
		nome VARCHAR(255) NOT NULL,
		techLeader VARCHAR(255) not null,
		horas INT NOT NULL,
		tickets INT NOT NULL
	)
	
*A porta padrão deve ser 1433

*A connection string esta configurada sem usuário e senha portanto é necessário configurar de acordo com o seu ambiente
