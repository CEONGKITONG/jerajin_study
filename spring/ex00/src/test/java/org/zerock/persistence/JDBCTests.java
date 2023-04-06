package org.zerock.persistence;

import java.sql.Connection;
import java.sql.DriverManager;

import org.junit.Test;

import lombok.extern.log4j.Log4j;

@Log4j
public class JDBCTests {
	
	@Test
	public void testConnection() {
		
		Connection con = null;
		
		try {
			//1. 드라이버 확인
			Class.forName("oracle.jdbc.driver.OracleDriver");
			log.info("드라이버 확인");
			//2. 연결
			con = DriverManager.getConnection("jdbc:oracle:thin:@localhost:1521:xe", "JAVA_TEST", "JAVA_TEST");
			log.info("연결 성공");
		} catch (Exception e) {
			// TODO: handle exception
			e.printStackTrace();
		} finally {
			try {
				con.close();				
			} catch (Exception e) {
				// TODO: handle exception
				e.printStackTrace();
			}
		}
	}

}
