package org.zerock.sample;

import static org.junit.Assert.assertNotNull;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

// 테스트 프로그램을 지정
@RunWith(SpringJUnit4ClassRunner.class)
// 설정 파일을 불러와서 적용시킨다.
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
@Log4j		// Log 를 파일 출력을 위한 
public class SampleTest {
	
	@Setter(onMethod_ = {@Autowired})
	private Restaurant restaurant;
	
	@Test
	public void testExist() {
		
		// Not Null 확인하는 메서드
		assertNotNull(restaurant);
		
		log.info(restaurant);
		log.info("-------------------------------------");
		log.info(restaurant.getChef());
	}

}
