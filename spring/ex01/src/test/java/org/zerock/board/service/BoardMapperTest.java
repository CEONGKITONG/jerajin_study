package org.zerock.board.service;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.zerock.board.mapper.BoardMapper;
import org.zerock.board.vo.BoardVO;

import lombok.Setter;
import lombok.extern.log4j.Log4j;

//테스트 프로그램을 지정
@RunWith(SpringJUnit4ClassRunner.class)
//설정 파일을 불러와서 적용시킨다.
@ContextConfiguration("file:src/main/webapp/WEB-INF/spring/root-context.xml")
@Log4j		// Log 를 파일 출력을 위한 
public class BoardMapperTest {

	@Setter(onMethod_ = @Autowired)
	private BoardMapper mapper;
	
	@Test
	public void testList() {
		log.info("\nMapper 리스트 테스트 ..................................");
		log.info(mapper.list());
		
	}
	
	@Test
	public void testView() {
		log.info("\nMapper 글보기 테스트 ..................................");
		log.info(mapper.view((long)1));
		
	}	
	
	@Test
	public void testWrite() {
		log.info("\nMapper 등록 테스트 ..................................");
		BoardVO vo = new BoardVO();
		vo.setTitle("테스트 제목");
		vo.setContent("테스트 내용");
		vo.setWriter("테스트 작성자");
		vo.setPw("1111");
		log.info(mapper.write(vo));
		
	}		
	
}
