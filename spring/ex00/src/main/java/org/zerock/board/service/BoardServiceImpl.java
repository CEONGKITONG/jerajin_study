package org.zerock.board.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;
import org.zerock.board.dao.BoardDAOImpl;

import lombok.Data;
import lombok.Setter;

// Spring 자동 생성 어노테이션 - @Controller, @Component, @Service, @Repository, @RestController, @Advice
//root-context.xml 에 설정이 되어 있어야 한다. (url 맵핑이 필요없는 경우) <annotation-driven /> <context:component-scan base-package="org.zerock" />
@Service
@Data
public class BoardServiceImpl {
	
	@Setter(onMethod_ = @Autowired)
	private BoardDAOImpl dao;

}
