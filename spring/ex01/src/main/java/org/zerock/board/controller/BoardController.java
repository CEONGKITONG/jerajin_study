package org.zerock.board.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.zerock.board.vo.BoardVO;

import lombok.extern.log4j.Log4j;

//자동 생성 어노테이션 - @Coontroller, @Service, @Repository, @Component, @RestController, @Advice
//@Coontroller - servlet-context.xml 에 선언, 그 외 어노테이션 - root-context.xml에 선언

@Controller
@RequestMapping("/board")
@Log4j
public class BoardController {
	
	@RequestMapping("/list.do")
	public String list() {
		log.info("게시판 리스트................................");
		return "board/list";
	}
	
	@RequestMapping("/view.do")
	public String view(long no, int inc) {
		log.info("게시판 글보기................................");
		log.info("no=" + no + ", inc=" + inc);
		return "board/view";
	}


	@GetMapping("/write.do")
	public String writeForm() {
		log.info("게시판 글쓰기 폼................................");
		return "board/write";
	}

	

	@PostMapping("/write.do")	
	public String write(BoardVO vo) {
		log.info("게시판 글쓰기 처리................................");
		log.info(vo);
		return "redirect:list.do";
	}

	
	@GetMapping("/update.do")
	public String updateForm() {
		log.info("게시판 수정 폼................................");
		return "board/update";
	}

	
	@PostMapping("/update.do")
	public String update() {
		log.info("게시판 글수정 처리................................");
		return "redirect:view.do?no=1&inc=1";
	}

	
	@PostMapping("/delete.do")
	public String delete() {
		log.info("게시판 글 삭제 처리................................");
		return "redirect:list.do";
	}
	

}
